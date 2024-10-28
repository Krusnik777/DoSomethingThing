using CodeBase.Gacha;
using CodeBase.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class UIGachaSceneStart : MonoBehaviour
    {
        [SerializeField] private GachaSceneStarter m_sceneStarter;
        [SerializeField] private GameObject m_panel;
        [SerializeField] private Button m_startButton;
        [SerializeField] private Animator m_startAnimator;

        private void Awake()
        {
            m_startButton.onClick.AddListener(OnStartButton);

            m_sceneStarter.EventOnSceneLaunch += OnSceneLaunch;

            if (!m_panel.activeInHierarchy) m_panel.SetActive(true);
            if (m_startAnimator.isActiveAndEnabled) m_startAnimator.enabled = false;
        }

        private void OnDestroy()
        {
            m_startButton.onClick.RemoveListener(OnStartButton);

            m_sceneStarter.EventOnSceneLaunch += OnSceneLaunch;
        }

        private void OnStartButton()
        {
            m_sceneStarter.StartGacha();
            m_panel.SetActive(false);

            m_startAnimator.enabled = false;
        }

        private void OnSceneLaunch()
        {
            m_startAnimator.enabled = true;
        }
    }
}
