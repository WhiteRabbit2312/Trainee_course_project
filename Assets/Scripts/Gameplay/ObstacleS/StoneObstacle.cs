using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraineeGame
{
    public class StoneObstacle : MonoBehaviour, IObstacleType
    {
        [SerializeField] private GameObject _prefab;
        public GameObject GetObstacle()
        {
            return _prefab;
        }
    }
}
