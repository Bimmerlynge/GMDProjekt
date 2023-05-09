using System;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Main_menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject firstSelected;

        private void Start()
        {
            SetFirstSelected();
        }

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
        
        public void SetFirstSelected()
        {
            var eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(firstSelected);
        }
    }
}
