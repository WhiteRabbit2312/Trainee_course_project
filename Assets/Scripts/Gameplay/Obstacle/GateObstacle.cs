using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraineeGame
{
    public class GateObstacle : MonoBehaviour, IObstacleType
    {
        [SerializeField] private ObstacleMovement _prefab;

        public ObstacleMovement GetObstacle()
        {
            ObstacleMovement gate = Instantiate(_prefab);
            return gate;
        }
    }
}
