using CodeBase.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class UIGameplaySceneStart : MonoBehaviour
    {
        [SerializeField] private GameplaySceneStarter m_gameplaySceneStarter;
        [SerializeField] private GameObject m_panel;
        [SerializeField] private Button m_startButton;
        [SerializeField] private Button m_giveUpButton;
        [SerializeField] private GameObject m_HUD;
        [SerializeField] private Animator m_startAnimator;
        [SerializeField] private TextMeshProUGUI m_startWords;

        private void Awake()
        {
            m_startButton.onClick.AddListener(OnStartButton);
            m_giveUpButton.onClick.AddListener(OnGiveUpButton);

            m_gameplaySceneStarter.EventOnSceneLaunch += OnSceneLaunch;

            if (!m_panel.activeInHierarchy) m_panel.SetActive(true);
            if (m_startAnimator.isActiveAndEnabled) m_startAnimator.enabled = false;
        }

        private void OnDestroy()
        {
            m_startButton.onClick.RemoveListener(OnStartButton);
            m_giveUpButton.onClick.RemoveListener(OnGiveUpButton);

            m_gameplaySceneStarter.EventOnSceneLaunch -= OnSceneLaunch;
        }

        private void OnStartButton()
        {
            m_panel.SetActive(false);
            m_gameplaySceneStarter.StartGame();
            m_HUD.SetActive(true);

            m_startAnimator.enabled = false;
        }

        private void OnGiveUpButton()
        {
            GlobalController.Instance.LoadStartScene();
        }

        private void OnSceneLaunch()
        {
            m_startAnimator.enabled = true;
            m_startWords.text = $"Δενό {GlobalController.PlayerProgress.CurrentDay}";
        }
    }
}
