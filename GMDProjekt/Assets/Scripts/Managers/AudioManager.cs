using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _soundEffect;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEffect(AudioClip clip)
    {
        _soundEffect.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        _music.PlayOneShot(clip);
    }


}
