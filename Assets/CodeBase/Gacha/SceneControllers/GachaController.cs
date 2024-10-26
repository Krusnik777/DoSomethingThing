using CodeBase.Configs;
using CodeBase.Gacha.Claw;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gacha
{
    public class GachaController : MonoBehaviour
    {
        [SerializeField] private GachaSpawner m_gachaSpawner;
        [SerializeField] private ClawCollector m_clawCollector;
        [SerializeField] private ClawMovement m_clawMovement;

        public event UnityAction<WeaponConfig> EventOnGachaEnd;

        public void Init()
        {
            m_gachaSpawner.SpawnPickups();

            m_clawCollector.EventOnClawPicked += OnClawPicked;
            m_clawMovement.EventOnDescentEnd += OnDescentEnd;
        }

        private void OnClawPicked(WeaponConfig config)
        {
            m_clawCollector.EventOnClawPicked -= OnClawPicked;
            m_clawMovement.EventOnDescentEnd -= OnDescentEnd;

            // Pickup Success
            Debug.Log("PICKED");

            EventOnGachaEnd?.Invoke(config);
        }

        private void OnDescentEnd()
        {
            m_clawCollector.EventOnClawPicked -= OnClawPicked;
            m_clawMovement.EventOnDescentEnd -= OnDescentEnd;

            // Pickup Failure
            Debug.Log("FAILURE");

            EventOnGachaEnd?.Invoke(null);
        }
    }
}
