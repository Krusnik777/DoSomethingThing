
using System.Collections;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroEffects : MonoBehaviour
    {
        [SerializeField] private HeroHealth m_heroHealth;
        [SerializeField] private GameObject m_hitEffect;

        private Coroutine hitRoutine;

        private void Start()
        {
            m_heroHealth.EventOnChanged += OnHealthChanged;

            if (m_hitEffect.activeInHierarchy) m_hitEffect.SetActive(false);
        }

        private void OnDestroy()
        {
            m_heroHealth.EventOnChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (hitRoutine != null) StopCoroutine(hitRoutine);

            hitRoutine = StartCoroutine(HitRoutine());
        }

        private IEnumerator HitRoutine()
        {
            m_hitEffect.SetActive(true);

            yield return new WaitForSeconds(2f);

            m_hitEffect.SetActive(false);
        }
    }
}
