using UnityEngine;

namespace CodeBase.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class BGMController : MonoBehaviour
    {
        [SerializeField] private AudioClip m_startMenuTheme;
        [SerializeField] private AudioClip m_gameOverTheme;
        [SerializeField] private AudioClip m_gameplaySceneStartTheme;
        [SerializeField] private AudioClip m_gachaSceneTheme;
        [SerializeField] private AudioClip m_vn1Theme;
        [SerializeField] private AudioClip m_vn2Theme;
        [SerializeField] private AudioClip m_vn3Theme;
        [SerializeField] private AudioClip[] m_audioClips;

        public float GameOverLength => m_gameOverTheme.length;

        private AudioSource audioSource;

        public void Init()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void StartPlayStartMenuBGM()
        {
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

        public void StartPlayStartSceneBGM()
        {
            audioSource.clip = m_gameplaySceneStartTheme;
            audioSource.loop = true;
            audioSource.Play();
        }

        public void StartPlayGachaSceneBGM()
        {
            audioSource.clip = m_gachaSceneTheme;
            audioSource.loop = true;
            audioSource.Play();
        }

        public void StartPlayVNTheme(int number)
        {
            switch (number)
            {
                case 1 : audioSource.clip = m_vn1Theme;
                    break;
                case 2 : audioSource.clip = m_vn2Theme;
                    break;
                case 3 : audioSource.clip = m_vn3Theme;
                    break;
                default: return;
            }

            audioSource.loop = true;
            audioSource.Play();
        }

        public void StartPlayRandomBGM()
        {
            int index = Random.Range(0, m_audioClips.Length);
            audioSource.clip = m_audioClips[index];
            audioSource.Play();
        }

        public void StopMusic()
        {
            audioSource.Stop();
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
