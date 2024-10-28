using CodeBase.Gacha;
using CodeBase.Configs;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeBase.UI
{
    public class UIGachaSceneEnd : MonoBehaviour
    {
        [SerializeField] private GachaController m_gachaController;
        [SerializeField] private GameObject m_panel;
        [SerializeField] private TextMeshProUGUI m_text;
        [SerializeField] private Button m_nextButton;

        private void Awake()
        {
            m_nextButton.onClick.AddListener(OnNextButton);
            m_gachaController.EventOnGachaEnd += OnGachaEnd;

            if (m_panel.activeInHierarchy) m_panel.SetActive(false);
        }

        private void OnDestroy()
        {
            m_nextButton.onClick.RemoveListener(OnNextButton);
            m_gachaController.EventOnGachaEnd -= OnGachaEnd;
        }

        private void OnNextButton()
        {
            if (GlobalController.GameMode == GameMode.Story)
            {
                /*
                int day = GlobalController.PlayerProgress.CurrentDay;
                GlobalController.Instance.LoadScene(Constants.GetSceneNameByDay(day));
                */
                GlobalController.Instance.LoadScene("GameplaySceneBase"); // TEMP for Tests
            }
            else
            {
                GlobalController.Instance.LoadScene("GameplaySceneBase"); // TEMP for Tests
            }
        }

        private void OnGachaEnd(WeaponConfig config)
        {
            if (config == null)
            {
                m_text.text = "You Got Nothing. Get Some Health";
                if (GlobalController.Instance != null)
                    GlobalController.PlayerProgress.HealthPoints++;
            }
            else
            {
                m_text.text = $"You Got Weapon: {config.Name}";

                if (GlobalController.Instance != null)
                    GlobalController.PlayerProgress.EquippedWeapon = config;
            }

            m_panel.SetActive(true);
        }
    }
}
