using UnityEngine;

namespace GameData
{
    public class PlayerPrefsHandler
    {
        private static readonly PlayerPrefsHandler instance = new();
        private PlayerPrefsHandler()
        {
            LoadPrefs();
        }

        public static PlayerPrefsHandler Instance => instance;

        public float MusicVolume { get; set; }
        public bool MusicMute { get; set; }
        public float EffectsVolume { get; set; }
        public bool EffectsMute { get; set; }
        

        private void LoadPrefs()
        {
            MusicVolume = PlayerPrefs.GetFloat("musicVolume");
            MusicMute = PlayerPrefs.GetInt("musicMute") == 1;
            EffectsVolume = PlayerPrefs.GetFloat("effectsVolume");
            EffectsMute = PlayerPrefs.GetInt("effectsMute") == 1;
        }

        public void Save()
        {
            PlayerPrefs.SetFloat("musicVolume", MusicVolume);
            PlayerPrefs.SetInt("musicMute", MusicMute ? 1 : 0);
            PlayerPrefs.SetFloat("effectsVolume", EffectsVolume);
            PlayerPrefs.SetInt("effectsMute", EffectsMute ? 1 : 0);
        }
        
    }
}