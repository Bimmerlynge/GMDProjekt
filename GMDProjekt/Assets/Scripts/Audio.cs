using UnityEngine;


public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void PlayClip()
    {
        AudioManager.Instance.PlayEffect(audioClip);
    }
}
