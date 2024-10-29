using UnityEngine;

namespace CodeBase.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXController : MonoBehaviour
    {
        [SerializeField] private AudioClip m_victorySound;
        [SerializeField] private AudioClip m_gachaGetSound;
        [SerializeField] private AudioClip m_gachaNotGetSound;

        private AudioSource audioSource;

        public void Init()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }

        public void PlayVictorySound()
        {
            audioSource.PlayOneShot(m_victorySound);
        }

        public void PlayGachaGetSound()
        {
            audioSource.PlayOneShot(m_gachaGetSound);
        }

        public void PlayGachaNotGetSound()
        {
            audioSource.PlayOneShot(m_gachaNotGetSound);
        }
    }
}
