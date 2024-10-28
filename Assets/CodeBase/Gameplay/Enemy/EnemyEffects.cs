using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyEffects : MonoBehaviour
    {
        [SerializeField] private EnemyHealth m_enemyHealth;
        [SerializeField] private GameObject m_hitEffectPrefab;

        private void Start()
        {
            m_enemyHealth.EventOnChanged += OnHealthChanged;
            m_enemyHealth.EventOnDie += OnDie;
        }

        private void OnDestroy()
        {
            m_enemyHealth.EventOnChanged -= OnHealthChanged;
            m_enemyHealth.EventOnDie -= OnDie;
        }

        private void OnHealthChanged()
        {
            var effect = Instantiate(m_hitEffectPrefab, transform.position, Quaternion.identity);

            Destroy(effect, 2f);
        }

        private void OnDie(object sender)
        {

        }
    }
}
