using CodeBase.Configs;
using CodeBase.Gameplay.Hero;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyConfig[] m_spawnableEnemies;
        [SerializeField] private float m_spawnTime;
        [SerializeField] private bool m_spawnAtStart;
        [SerializeField] private HeroHealth m_heroHealth; // temp

        public event UnityAction<EnemyHealth> EventOnSpawn;

        private float timer;

        private void OnEnable()
        {
            if (m_spawnAtStart) timer = m_spawnTime;
            else timer = 0;
        }

        private void Update()
        {
            if (!SpawnController.SpawnIsAvailable) return;

            // TEMP

            if (m_heroHealth == null)
            {
                enabled = false;

                return;
            }

            // TEMP END

            timer += Time.deltaTime;

            if (timer >= m_spawnTime)
            {
                Spawn();

                timer = 0;
            }
        }

        private void Spawn()
        {
            EnemyConfig enemyConfig = GetRandomEnemyConfigFromList();

            if (enemyConfig == null)
            {
                Debug.LogWarning("Couldn't spawn");

                return;
            }

            GameObject enemy = Instantiate(enemyConfig.Prefab);

            enemy.transform.position = transform.position;

            IEnemyConfigInstaller[] enemyConfigInstallers = enemy.GetComponentsInChildren<IEnemyConfigInstaller>();

            for (int i = 0; i < enemyConfigInstallers.Length; i++)
            {
                enemyConfigInstallers[i].InstallConfig(enemyConfig);
            }

            // TEMP

            if (m_heroHealth != null)
            {
                enemy.GetComponent<EnemyFollowHero>().SetFollowTarget(m_heroHealth.gameObject);
                enemy.GetComponent<EnemyCollide>().SetHeroHealth(m_heroHealth);
            }

            // TEMP END

            EventOnSpawn?.Invoke(enemy.GetComponent<EnemyHealth>());
        }

        private EnemyConfig GetRandomEnemyConfigFromList()
        {
            int index = Random.Range(0, m_spawnableEnemies.Length);

            return m_spawnableEnemies[index];
        }

        #if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }

        #endif
    }
}
