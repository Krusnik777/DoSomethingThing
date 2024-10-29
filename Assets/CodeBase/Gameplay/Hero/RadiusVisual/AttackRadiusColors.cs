using System.Collections;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class AttackRadiusColors : MonoBehaviour
    {
        [SerializeField] private LineRenderer m_lineRenderer;
        [SerializeField] private Gradient m_defaultGradient;
        [SerializeField] private Gradient m_cooldownGradient_Default;
        [SerializeField] private Gradient m_cooldownGradient_Trasparent;

        public bool IsDefault => m_lineRenderer.colorGradient == m_defaultGradient;

        private bool hasVisibleColor;

        public void ChangeColorToDefault()
        {
            m_lineRenderer.colorGradient = m_defaultGradient;
        }

        public void ChangeColorToCooldown(float time)
        {
            StartCoroutine(CooldownRoutine(time));
        }

        private void ChangeCoolDownColors()
        {
            if (hasVisibleColor)
            {
                m_lineRenderer.colorGradient = m_cooldownGradient_Trasparent;
                hasVisibleColor = false;
            }
            else
            {
                m_lineRenderer.colorGradient = m_cooldownGradient_Default;
                hasVisibleColor = true;
            }
        }

        private IEnumerator CooldownRoutine(float time)
        {
            ChangeCoolDownColors();

            float elapsed = 0f;
            int frames = 0;

            while (elapsed < time)
            {
                yield return null;

                frames++;

                elapsed += Time.deltaTime;

                if (frames >= 50)
                {
                    ChangeCoolDownColors();

                    frames = 0;
                }
            }

            ChangeColorToDefault();
        }
    }
}
