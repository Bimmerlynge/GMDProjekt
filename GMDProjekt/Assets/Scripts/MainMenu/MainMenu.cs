using DefaultNamespace;
using UnityEngine;

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
