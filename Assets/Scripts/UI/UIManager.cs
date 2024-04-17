using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TraineeGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _inGamePanel;

        private void Awake()
        {
            GameManager.onGameplay += CloseMenuTab;
            GameManager.onEndGame += EnablegameOverPanel;
        }
        
        public void StartButton()
        {
            GameManager.onGameplay?.Invoke();
        }

        private void CloseMenuTab()
        {
            _mainPanel.SetActive(false);
        }

        private void EnablegameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }

        public void ExitButton()
        {
            Application.Quit();
        }


    }
}