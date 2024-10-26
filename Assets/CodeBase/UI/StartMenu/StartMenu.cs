using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private Button m_startButton;
        [SerializeField] private Button m_endButton;

        // ALSO SETTINGS PANEL

        private void Awake()
        {
            m_startButton.onClick.AddListener(OnStartButton);
            m_endButton.onClick.AddListener(OnEndButton);
        }

        private void OnDestroy()
        {
            m_startButton.onClick.RemoveListener(OnStartButton);
            m_endButton.onClick.RemoveListener(OnEndButton);
        }

        private void OnStartButton()
        {
            //GlobalController.Instance.LoadScene(Constants.VN_StartSceneName);

            GlobalController.Instance.LoadScene("GameplaySceneBase"); // TEMP for Tests
        }

        private void OnEndButton()
        {
            Application.Quit();
        }
    }
}
