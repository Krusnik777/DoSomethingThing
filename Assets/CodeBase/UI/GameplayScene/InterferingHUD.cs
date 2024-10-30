using CodeBase.Gameplay;
using CodeBase.Gameplay.Enemy;
using System.Collections;
using UnityEngine;

namespace CodeBase.UI
{
    public class InterferingHUD : MonoBehaviour
    {
        [SerializeField] private EnemySpawner m_spawner;
        [SerializeField] private GameplayController m_gameplayController;
        [SerializeField] private GameObject m_panel;
        [SerializeField] private Animator m_panelAnimator;
        [SerializeField] private float m_interferingTime = 5f;
        [SerializeField] private float m_closingTime = 2f;

        private Coroutine showcaseRoutine;

        private void Start()
        {
            if (m_spawner != null) m_spawner.EventOnSpawn += OnSpawn;

            m_gameplayController.EventOnSuccess += ClosePanel;
            m_gameplayController.EventOnFailure += ClosePanel;

            if (m_panel.activeInHierarchy) m_panel.SetActive(false);
        }

        private void OnDestroy()
        {
            if (m_spawner != null) m_spawner.EventOnSpawn -= OnSpawn;

            m_gameplayController.EventOnSuccess -= ClosePanel;
            m_gameplayController.EventOnFailure -= ClosePanel;
        }

        private void OnSpawn(EnemyHealth enemyHealth)
        {
            if (showcaseRoutine != null) return;

            showcaseRoutine = StartCoroutine(ShowcasePanelRoutine());
        }

        private void ClosePanel()
        {
            if (showcaseRoutine != null) StopAllCoroutines();

            if (m_panel.activeInHierarchy) m_panel.SetActive(false);
        }

        private IEnumerator ShowcasePanelRoutine()
        {
            m_panel.SetActive(true);

            yield return new WaitForSeconds(m_interferingTime);

            m_panelAnimator.SetTrigger("Close");

            yield return new WaitForSeconds(m_closingTime);

            m_panel.SetActive(false);

            showcaseRoutine = null;
        }
    }
}
