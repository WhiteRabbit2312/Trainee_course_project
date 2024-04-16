using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraineeGame
{
    public enum GameState
    {
        PreGame,
        Gameplay,
        EndGame
    }

    public class GameManager : MonoBehaviour
    {
        public static GameState State
        {
            get;
            set;
        }

        private void Awake()
        {
            State = GameState.PreGame;

        }

        public void StartButton()
        {
            State = GameState.Gameplay;

        }

        public void NewGameButton()
        {
            State = GameState.PreGame;
        }
    }
}
