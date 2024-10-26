using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroHealth : HealthPoints
    {
        [SerializeField] protected int m_maxPossibleValue = 5;

        public void SetHealthPoints(int value)
        {
            if (value > m_maxPossibleValue)
            {
                m_currentValue = m_maxPossibleValue;
            }
            else
            {
                m_currentValue = value;
            }
        }

        private void AddHealth(int value)
        {
            if (value == 0) return;

            m_currentValue += value;

            if (m_currentValue > m_maxPossibleValue)
            {
                m_currentValue = m_maxPossibleValue;
            }

            InvokeChangedEvent();
        }
    }
}
