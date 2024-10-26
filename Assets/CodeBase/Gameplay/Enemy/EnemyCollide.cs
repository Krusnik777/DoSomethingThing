using CodeBase.Configs;
using CodeBase.Gameplay.Hero;
using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyCollide : MonoBehaviour, IEnemyConfigInstaller
    {
        [SerializeField] private EnemyFollowHero m_enemyFollowHero;
        [SerializeField] private EnemyHealth m_enemyHealth;
        [SerializeField] private int m_damage = 1;  // Serialize is for debug or hand input
        [SerializeField] private HeroHealth m_heroHealth;  // Serialize is for debug or hand input

        public void InstallConfig(EnemyConfig config)
        {
            m_damage = config.Damage;
        }

        public void SetHeroHealth(HeroHealth heroHealth) => m_heroHealth = heroHealth;

        private void Start()
        {
            m_enemyFollowHero.EventOnReached += OnReachedHero;
        }

        private void OnDestroy()
        {
            m_enemyFollowHero.EventOnReached -= OnReachedHero;
        }

        private void OnReachedHero()
        {
            if (m_heroHealth != null) m_heroHealth.ApplyDamage(m_enemyHealth, m_damage);

            m_enemyHealth.ApplyDamage(m_enemyHealth, 999);
        }
    }
}
