using CodeBase.Gameplay;
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

        private void Awake()
        {
            m_startButton.onClick.AddListener(OnStartButton);
            m_giveUpButton.onClick.AddListener(OnGiveUpButton);

            if (!m_panel.activeInHierarchy) m_panel.SetActive(true);
        }

        private void OnDestroy()
        {
            m_startButton.onClick.RemoveListener(OnStartButton);
            m_giveUpButton.onClick.RemoveListener(OnGiveUpButton);
        }

        private void OnStartButton()
        {
            m_panel.SetActive(false);
            m_gameplaySceneStarter.StartGame();
            m_HUD.SetActive(true);
        }

        private void OnGiveUpButton()
        {
            // Return To Main Menu
        }
    }
}
