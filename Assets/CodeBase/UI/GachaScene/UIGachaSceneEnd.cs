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
                int day = GlobalController.PlayerProgress.CurrentDay;

                if (day <= 2)  // TEMP for Tests
                {
                    GlobalController.Instance.LoadScene(Constants.GetSceneNameByDay(day));
                }
                else
                {
                    GlobalController.Instance.LoadScene("GameplaySceneBase");
                }
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
                m_text.text = "Увы, ничего.\n + 1 очко здоровья";
                if (GlobalController.Instance != null)
                {
                    GlobalController.PlayerProgress.HealthPoints++;
                    GlobalController.SFXController.PlayGachaNotGetSound();
                }
            }
            else
            {
                m_text.text = $"Получено: {config.Name}.\n" +
                    $"Урон: {config.Damage}.\n" +
                    $"Радиус: {config.Radius}.\n" +
                    $"Задерка: {config.Cooldown}.";

                if (GlobalController.Instance != null)
                {
                    GlobalController.PlayerProgress.EquippedWeapon = config;
                    GlobalController.SFXController.PlayGachaGetSound();
                }
            }

            m_panel.SetActive(true);
        }
    }
}
