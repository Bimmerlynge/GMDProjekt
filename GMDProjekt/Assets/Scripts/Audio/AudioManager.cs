using DefaultNamespace;
using UnityEngine;

namespace Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] private AudioSource _music;
        [SerializeField] private AudioSource _soundEffect;
        public void PlayEffect(AudioClip clip)
        {
            _soundEffect.PlayOneShot(clip);
        }

        public void PlayMusic(AudioClip clip)
        {
            if (_music.isPlaying) return;
            _music.PlayOneShot(clip);
        }

        public void SetMusicVolume(float value)
        {
            _music.volume = value;
        }

        public void SetMusicMute(bool value)
        {
            _music.mute = value;
        }

        public void SetEffectsVolume(float value)
        {
            _soundEffect.volume = value;
        }

        public void SetEffectsMute(bool value)
        {
            _soundEffect.mute = value;
        }
    }
}

