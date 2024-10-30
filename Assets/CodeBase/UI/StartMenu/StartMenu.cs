using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private SettingsPanel m_settingsPanel;
        [Header("Buttons")]
        [SerializeField] private Button m_startButton;
        [SerializeField] private Button m_startInfiniteButton;
        [SerializeField] private Button m_settingsButton;
        [SerializeField] private Button m_endButton;

        private void Awake()
        {
            m_startButton.onClick.AddListener(OnStartButton);
            m_startInfiniteButton.onClick.AddListener(OnStartInfiniteButton);
            m_settingsButton.onClick.AddListener(OnSettingsButton);
            m_endButton.onClick.AddListener(OnEndButton);
        }

        private void OnDestroy()
        {
            m_startButton.onClick.RemoveListener(OnStartButton);
            m_startInfiniteButton.onClick.RemoveListener(OnStartInfiniteButton);
            m_settingsButton.onClick.RemoveListener(OnSettingsButton);
            m_endButton.onClick.RemoveListener(OnEndButton);
        }

        private void OnStartButton()
        {
            GlobalController.Instance.SetGameMode(GameMode.Story);
            GlobalController.Instance.LoadScene(Constants.VN_StartSceneName);
        }

        private void OnStartInfiniteButton()
        {
            GlobalController.Instance.SetGameMode(GameMode.Infinite);

            int randomStartLevelId = Random.Range(1, 3);

            GlobalController.Instance.LoadScene(Constants.GetSceneNameByDay(randomStartLevelId));
        }

        private void OnSettingsButton()
        {
            m_settingsPanel.InitPanel();
        }

        private void OnEndButton()
        {
            Application.Quit();
        }
    }
}
