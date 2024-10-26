using CodeBase.Configs;
using System.Collections.Generic;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyHealth : HealthPoints, IEnemyConfigInstaller
    {
        public void InstallConfig(EnemyConfig config)
        {
            m_currentValue = config.HealthPoints;
        }

        private static List<EnemyHealth> allEnemies;

        public static void CleanupRemainingEnemies()
        {
            for (int i = allEnemies.Count - 1; i >= 0; i--)
            {
                Destroy(allEnemies[i].gameObject);
            }
        }

        private void OnEnable()
        {
            if (allEnemies == null) allEnemies = new List<EnemyHealth>();

            allEnemies.Add(this);
        }

        private void OnDestroy()
        {
            allEnemies.Remove(this);
        }
    }
}
