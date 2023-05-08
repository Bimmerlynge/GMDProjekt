using UnityEngine;

namespace Audio
{
    public class SoundEffect : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;

        public void PlayClip()
        {
            AudioManager.Instance.PlayEffect(audioClip);
        }
    }
}
