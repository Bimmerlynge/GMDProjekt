using UnityEngine;

namespace Audio
{
    public class Music : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;

        public void PlaySong()
        {
            AudioManager.Instance.PlayMusic(audioClip);
        }
    }
}