using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TraineeGame
{
    public class MainGamePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _mainPanel;//TODO
        [SerializeField] private GameObject _gameOverPanel;//TODO
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        private void Awake()
        {
            GameManager.onGameplay += CloseMenuTab;
            startButton.onClick.AddListener(StartGame);
            exitButton.onClick.AddListener(ExitButton);
        }

        public void StartGame()
        {
            GameManager.Gameplay();
        }

        private void CloseMenuTab()
        {
            _mainPanel.SetActive(false);
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
