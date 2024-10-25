using UnityEngine;

namespace CodeBase.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class BGMController : MonoBehaviour
    {
        [SerializeField] private AudioClip m_startMenuTheme;
        [SerializeField] private AudioClip[] m_audioClips;

        private AudioSource audioSource;

        public void Init()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void StartPlayStartMenuBGM()
        {
            audioSource.clip = m_startMenuTheme;
            audioSource.Play();
        }

        public void StartPlayRandomBGM()
        {
            int index = Random.Range(0, m_audioClips.Length);
            audioSource.clip = m_audioClips[index];
            audioSource.Play();
        }

        public void Pause()
        {
            audioSource.Pause();
        }

        public void UnPause()
        {
            audioSource.UnPause();
        }
    }
}
