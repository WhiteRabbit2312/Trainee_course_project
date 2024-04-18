using UnityEngine;
using System;

namespace TraineeGame
{
    public class GameManager : MonoBehaviour
    {
        //TODO: make a static class and add unsubscription 
        public static Action onPreGame;
        public static Action onGameplay;
        public static Action onEndGame;
        public void StartGame()
        {
            onPreGame?.Invoke();
        }
    }
}
