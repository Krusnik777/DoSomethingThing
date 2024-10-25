using CodeBase.Gameplay.Hero;
using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyCollide : MonoBehaviour
    {
        [SerializeField] private EnemyFollowHero m_enemyFollowHero;
        [SerializeField] private EnemyHealth m_enemyHealth;
        [SerializeField] private HeroHealth m_heroHealth; //temp

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
            if (m_heroHealth != null) m_heroHealth.ApplyDamage(1); // TEMP

            m_enemyHealth.ApplyDamage(999);
        }
    }
}
