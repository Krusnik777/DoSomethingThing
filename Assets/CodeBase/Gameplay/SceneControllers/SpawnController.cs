using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Hero;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private EnemySpawner[] m_enemySpawners;
        [SerializeField] private int m_maxSpawns = 6;
        [SerializeField] private int m_minSpawns = 4;

        public event UnityAction<object> EventOnSpawnDead;

        private bool spawnIsAvailable;
        public bool SpawnIsAvailable => spawnIsAvailable && heroHealth != null;

        private HeroHealth heroHealth;
        public HeroHealth HeroHealth => heroHealth;

        private int spawnedEnemies;

        public void Init(HeroHealth heroHealth)
        {
            this.heroHealth = heroHealth;

            heroHealth.EventOnDie += OnHeroDeath;

            for (int i = 0; i < m_enemySpawners.Length; i++)
            {
                m_enemySpawners[i].gameObject.SetActive(true);
                m_enemySpawners[i].Setup(this);
                m_enemySpawners[i].EventOnSpawn += OnSpawn;
            }

            spawnedEnemies = 0;

            spawnIsAvailable = true;
        }

        private void OnDisable()
        {
            for (int i = 0; i < m_enemySpawners.Length; i++)
            {
                m_enemySpawners[i].gameObject.SetActive(false);
                m_enemySpawners[i].EventOnSpawn -= OnSpawn;
            }

            spawnIsAvailable = false;
        }

        private void OnHeroDeath(object sender)
        {
            enabled = false;
        }

        private void OnSpawn(EnemyHealth enemyHealth)
        {
            spawnedEnemies++;
            enemyHealth.EventOnDie += OnSpawnsDie;

            if (spawnedEnemies >= m_maxSpawns) spawnIsAvailable = false;
        }

        private void OnSpawnsDie(object sender)
        {
            EventOnSpawnDead?.Invoke(sender);

            spawnedEnemies--;

            if (spawnedEnemies <= m_minSpawns) spawnIsAvailable = true;
        }
    }
}
