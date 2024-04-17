using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TraineeGame;

    public class StoneObstacle : MonoBehaviour, IObstacleType
    {
        [SerializeField] private ObstacleMovement _prefab;
        public ObstacleMovement GetObstacle()
        {
            ObstacleMovement stone = Instantiate(_prefab);
            return stone;
        }
    }

