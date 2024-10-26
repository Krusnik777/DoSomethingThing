using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay
{
    public class HealthPoints : MonoBehaviour
    {
        public event UnityAction EventOnChanged;
        public event UnityAction<object> EventOnDie;

        [SerializeField] protected int m_currentValue;

        public int CurrentValue => m_currentValue;

        public void ApplyDamage(object sender, int damage)
        {
            if (m_currentValue == 0 || damage == 0) return;

            m_currentValue -= damage;

            if (m_currentValue <= 0)
            {
                m_currentValue = 0;
                EventOnDie?.Invoke(sender);
            }

            InvokeChangedEvent();
        }

        protected void InvokeChangedEvent()
        {
            EventOnChanged?.Invoke();
        }
    }
}
