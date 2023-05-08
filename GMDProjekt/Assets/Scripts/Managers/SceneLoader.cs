using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    [SerializeField]
    private int currentStage = 0;

    private readonly float loadBuffer = 1f;
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
    
    public void LoadNextScene()
    {
        var stageNumberString = $"{(currentStage < 9 ? "0" + ++currentStage : ++currentStage)}";
        SceneManager.LoadScene($"stage{stageNumberString}");
        StartCoroutine(LoadTime());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        currentStage = 0;
        StartCoroutine(LoadTime());
    }

    private IEnumerator LoadTime()
    {
        yield return new WaitForSeconds(loadBuffer);
        GameStateHandler.Instance.CurrentState = GameState.Running;
    }


}
