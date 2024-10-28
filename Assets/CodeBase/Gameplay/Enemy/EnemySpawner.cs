using CodeBase.Configs;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyConfig[] m_spawnableEnemies;
        [SerializeField] private float m_spawnTime;
        [SerializeField] private bool m_spawnAtStart;
        [SerializeField] private float m_checkDistance = 2f;
        [SerializeField] private GameObject m_spawnEffect;

        private SpawnController parentController;

        public event UnityAction<EnemyHealth> EventOnSpawn;

        private float timer;

        private Coroutine effectRoutine;

        public void Setup(SpawnController spawnController) => parentController = spawnController;

        private void OnEnable()
        {
            if (m_spawnAtStart) timer = m_spawnTime;
            else timer = 0;
        }

        private void Update()
        {
            if (!parentController.SpawnIsAvailable) return;

            timer += Time.deltaTime;

            if (timer >= m_spawnTime)
            {
                var distance = Vector3.Distance(transform.position, parentController.HeroHealth.transform.position);

                if (distance > m_checkDistance) Spawn();

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

            GameObject enemy = Instantiate(enemyConfig.Prefab, transform.position, Quaternion.identity);

            IEnemyConfigInstaller[] enemyConfigInstallers = enemy.GetComponentsInChildren<IEnemyConfigInstaller>();

            for (int i = 0; i < enemyConfigInstallers.Length; i++)
            {
                enemyConfigInstallers[i].InstallConfig(enemyConfig);
            }

            enemy.GetComponent<EnemyFollowHero>().SetFollowTarget(parentController.HeroHealth.gameObject);
            enemy.GetComponent<EnemyCollide>().SetHeroHealth(parentController.HeroHealth);

            if (effectRoutine != null) StopCoroutine(effectRoutine);

            effectRoutine = StartCoroutine(EffectRoutine());

            EventOnSpawn?.Invoke(enemy.GetComponent<EnemyHealth>());
        }

        private EnemyConfig GetRandomEnemyConfigFromList()
        {
            int index = Random.Range(0, m_spawnableEnemies.Length);

            return m_spawnableEnemies[index];
        }

        private IEnumerator EffectRoutine()
        {
            m_spawnEffect.SetActive(true);

            yield return new WaitForSeconds(2f);

            m_spawnEffect.SetActive(false);
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
