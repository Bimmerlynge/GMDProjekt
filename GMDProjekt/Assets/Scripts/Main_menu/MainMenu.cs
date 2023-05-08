using DefaultNamespace;
using UnityEngine;

namespace Main_menu
{
    public class MainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneLoader.Instance.LoadNextScene();
            GameStateHandler.Instance.StartTimer();
        }
        public void Settings()
        {
            UIManager.Instance.SetSettingsPanelState(true);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
