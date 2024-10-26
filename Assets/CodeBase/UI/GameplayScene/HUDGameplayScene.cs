using CodeBase.Gameplay;
using CodeBase.Gameplay.Hero;
using System;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class HUDGameplayScene : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_healthPoints;
        [SerializeField] private TextMeshProUGUI m_killsCounter;
        [SerializeField] private TextMeshProUGUI m_time;
        [SerializeField] private GameplayController m_gameplayController;
        [SerializeField] private HeroHealth m_heroHealth;

        private void Start()
        {
            m_killsCounter.text = "0";
            m_time.text = "00:00";

            m_gameplayController.KillsCounter.EventOnKillsUpdated += OnKillsUpdated;
            m_heroHealth.EventOnChanged += UpdateHealthPoints;

            UpdateHealthPoints();
        }

        private void OnDestroy()
        {
            m_gameplayController.KillsCounter.EventOnKillsUpdated -= OnKillsUpdated;
            m_heroHealth.EventOnChanged -= UpdateHealthPoints;
        }

        private void LateUpdate()
        {
            if (!m_gameplayController.TimeCounter.isActiveAndEnabled) return;

            m_time.text = TimeSpan.FromSeconds(m_gameplayController.TimeCounter.CountedValue).ToString(@"mm\:ss");
        }

        private void OnKillsUpdated(int currentKills)
        {
            m_killsCounter.text = currentKills.ToString();
        }

        private void UpdateHealthPoints()
        {
            m_healthPoints.text = m_heroHealth.CurrentValue.ToString();
        }
    }
}
