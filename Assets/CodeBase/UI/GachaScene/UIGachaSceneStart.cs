using CodeBase.Gacha;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class UIGachaSceneStart : MonoBehaviour
    {
        [SerializeField] private GameObject m_panel;
        [SerializeField] private Button m_startButton;
        [SerializeField] private GachaSceneStarter m_sceneStarter;

        private void Awake()
        {
            m_startButton.onClick.AddListener(OnStartButton);

            if (!m_panel.activeInHierarchy) m_panel.SetActive(true);
        }

        private void OnDestroy()
        {
            m_startButton.onClick.RemoveListener(OnStartButton);
        }

        private void OnStartButton()
        {
            m_sceneStarter.StartGacha();
            m_panel.SetActive(false);
        }
    }
}
