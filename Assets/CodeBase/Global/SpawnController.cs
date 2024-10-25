using CodeBase.Gameplay.Enemy;
using UnityEngine;

namespace CodeBase
{
    // TEMP CLASS
    public class SpawnController : MonoBehaviour
    {
        public static bool SpawnIsAvailable;

        [SerializeField] private EnemySpawner[] m_enemySpawners;
        [SerializeField] private int m_maxSpawns = 6;
        [SerializeField] private int m_minSpawns = 4;

        private int currentSpawns;

        private void Start()
        {
            for (int i = 0; i < m_enemySpawners.Length; i++)
            {
                m_enemySpawners[i].gameObject.SetActive(true);
                m_enemySpawners[i].EventOnSpawn += OnSpawn;
            }

            SpawnIsAvailable = true;
        }

        private void OnDestroy()
        {
            for (int i = 0; i < m_enemySpawners.Length; i++)
            {
                m_enemySpawners[i].EventOnSpawn -= OnSpawn;
            }
        }

        private void OnSpawn(EnemyHealth enemyHealth)
        {
            currentSpawns++;
            enemyHealth.EventOnDie += OnSpawnsDie;

            if (currentSpawns >= m_maxSpawns) SpawnIsAvailable = false;
        }

        private void OnSpawnsDie()
        {
            currentSpawns--;

            if (currentSpawns <= m_minSpawns) SpawnIsAvailable = true;
        }
    }
}
