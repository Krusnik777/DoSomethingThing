using UnityEngine;
using UnityEngine.Audio;

namespace CodeBase.Settings
{
    public class SoundVolumeController : MonoBehaviour
    {
        private const string _MusicVolume = "BGMVolume";
        private const string _SFXVolume = "SFXVolume";

        [SerializeField] private AudioMixer m_audioMixer;
        [SerializeField] private float m_virtualStep = 20;

        private float currentMusicVolume = 0;
        public float CurrentMusicVolume => currentMusicVolume;
        private float currentSFXVolume = 0;
        public float CurrentSoundVolume => currentSFXVolume;

        public void Init()
        {
            SetMusicVolume(1);
            SetSoundVolume(1);
        }

        public void SetMusicVolume(float volume)
        {
            SetVolume(_MusicVolume, volume);
            currentMusicVolume = volume;
        }

        public void SetSoundVolume(float volume)
        {
            SetVolume(_SFXVolume, volume);
            currentSFXVolume = volume;
        }

        private void SetVolume(string name, float value)
        {
            m_audioMixer.SetFloat(name, Mathf.Log10(value) * m_virtualStep);
        }
    }
}
