using UnityEngine;

namespace CodeBase.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXController : MonoBehaviour
    {
        //[SerializeField] private AudioClip m_sound;

        private AudioSource audioSource;

        public void Init()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
