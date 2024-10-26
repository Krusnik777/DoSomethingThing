using CodeBase.Gameplay;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class UIGameplaySceneEnd : MonoBehaviour
    {
        [SerializeField] private GameplayController m_gameplayController;
        [SerializeField] private GameObject m_panel;
        [SerializeField] private Button m_nextButton;
        [SerializeField] private GameObject m_gameOverPanel;
        [SerializeField] private GameObject m_HUD;

        private void Awake()
        {
            m_nextButton.onClick.AddListener(OnNextButton);
            m_gameplayController.EventOnSuccess += OnSuccess;
            m_gameplayController.EventOnFailure += OnFailure;

            if (m_panel.activeInHierarchy) m_panel.SetActive(false);
            if (m_gameOverPanel.activeInHierarchy) m_gameOverPanel.SetActive(false);
        }

        private void OnDestroy()
        {
            m_nextButton.onClick.RemoveListener(OnNextButton);
            m_gameplayController.EventOnSuccess -= OnSuccess;
            m_gameplayController.EventOnFailure -= OnFailure;
        }

        private void OnNextButton()
        {
            // TO NEXT SCENE - GACHA OR FINAL

            // TEMP
            GlobalController.Instance.LoadGachaScene();
        }

        private void OnSuccess()
        {
            m_panel.SetActive(true);
            m_HUD.SetActive(false);
        }

        private void OnFailure()
        {
            m_HUD.SetActive(false);
            m_gameOverPanel.SetActive(true);

            StartCoroutine(ReturnToStartMenuRoutine());
        }

        private IEnumerator ReturnToStartMenuRoutine()
        {
            yield return new WaitForSeconds(2f);

            GlobalController.Instance.LoadStartScene();
        }
    }
}
