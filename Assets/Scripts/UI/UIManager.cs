using UnityEngine;


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

        public void RespawnGameButton()
        {

        }

        public void ReturnToMenuButton()
        {
            GameManager.onPreGame.Invoke();
            _gameOverPanel.SetActive(false);
            _mainPanel.SetActive(true);
        }
    }
}