using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private GameObject m_panel;
        [SerializeField] private Button m_returnButton;
        [SerializeField] private Slider m_sfxSlider;
        [SerializeField] private Slider m_musicSlider;

        public void InitPanel()
        {
            m_panel.SetActive(true);

            m_sfxSlider.value = GlobalController.SoundVolumeController.CurrentSoundVolume;
            m_musicSlider.value = GlobalController.SoundVolumeController.CurrentMusicVolume;
        }

        private void Start()
        {
            m_returnButton.onClick.AddListener(ReturnToStartMenu);

            m_sfxSlider.onValueChanged.AddListener(OnSFXVolumeChange);
            m_musicSlider.onValueChanged.AddListener(OnMusicVolumeChange);
        }

        private void OnDestroy()
        {
            m_returnButton.onClick.RemoveListener(ReturnToStartMenu);

            m_sfxSlider.onValueChanged.RemoveListener(OnSFXVolumeChange);
            m_musicSlider.onValueChanged.RemoveListener(OnMusicVolumeChange);
        }

        private void ReturnToStartMenu()
        {
            m_panel.SetActive(false);
        }

        private void OnSFXVolumeChange(float value)
        {
            GlobalController.SoundVolumeController.SetSoundVolume(value);
        }

        private void OnMusicVolumeChange(float value)
        {
            GlobalController.SoundVolumeController.SetMusicVolume(value);
        }
    }
}
