using CodeBase.Configs;
using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyHealth : HealthPoints, IEnemyConfigInstaller
    {
        public void InstallConfig(EnemyConfig config)
        {
            m_currentValue = config.HealthPoints;
        }
    }
}
