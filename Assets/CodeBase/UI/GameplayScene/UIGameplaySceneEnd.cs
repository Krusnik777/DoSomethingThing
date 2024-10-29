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

            if (GlobalController.GameMode == GameMode.Story)
            {
                if (GlobalController.PlayerProgress.CurrentDay >= 3)
                {
                    //GlobalController.Instance.LoadScene(Constants.VN_GameEndSceneName);
                    GlobalController.Instance.LoadStartScene(); // TEMP

                    return;
                }
            }

            GlobalController.Instance.LoadGachaScene();
        }

        private void OnSuccess()
        {
            m_panel.SetActive(true);
            m_HUD.SetActive(false);

            GlobalController.BGMController.StopMusic();
            GlobalController.SFXController.PlayVictorySound();
        }

        private void OnFailure()
        {
            m_HUD.SetActive(false);
            m_gameOverPanel.SetActive(true);

            StartCoroutine(GameOverRoutine());
        }

        private IEnumerator GameOverRoutine()
        {
            float seconds = GlobalController.BGMController.GameOverLength;

            GlobalController.BGMController.StartPlayGameOverBGM();

            yield return new WaitForSeconds(seconds);

            //GlobalController.Instance.LoadScene(Constants.VN_GameOverSceneName);
            GlobalController.Instance.LoadStartScene(); // TEMP
        }
    }
}
