using UnityEngine;

namespace CodeBase.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class BGMController : MonoBehaviour
    {
        [SerializeField] private AudioClip m_startMenuTheme;
        [SerializeField] private AudioClip m_gameOverTheme;
        [SerializeField] private AudioClip[] m_audioClips;

        public float GameOverLength => m_gameOverTheme.length;

        private AudioSource audioSource;

        public void Init()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void StartPlayStartMenuBGM()
        {
            if (m_startMenuTheme == null) return;

            audioSource.clip = m_startMenuTheme;
            audioSource.loop = true;
            audioSource.Play();
        }

        public void StartPlayGameOverBGM()
        {
            audioSource.clip = m_gameOverTheme;
            audioSource.loop = false;
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
