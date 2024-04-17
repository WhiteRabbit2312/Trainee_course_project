using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraineeGame
{
    public class GateObstacle : MonoBehaviour, IObstacleType
    {
        [SerializeField] private GameObject _prefab;

        public GameObject GetObstacle()
        {
            GameObject gate = Instantiate(_prefab);
            return gate;
        }
    }
}
