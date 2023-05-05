using UnityEngine;


public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void PlayClip()
    {
        AudioManager.Instance.PlayEffect(audioClip);
    }
}
