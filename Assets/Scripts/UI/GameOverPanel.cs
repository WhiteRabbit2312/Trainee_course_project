using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TraineeGame
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _mainPanel;//TODO
        [SerializeField] private GameObject _gameOverPanel;//TODO
        [SerializeField] private Button returnToMenuButton;

        private void Awake()
        {
            returnToMenuButton.onClick.AddListener(ReturnToMenuButton);
            GameManager.onEndGame += EnablegameOverPanel;
        }

        public void ReturnToMenuButton()
        {
            _gameOverPanel.SetActive(false);
            _mainPanel.SetActive(true);
            GameManager.PreGame();
        }

        private void EnablegameOverPanel()
        {

            _gameOverPanel.SetActive(true);
        }
    }
}
