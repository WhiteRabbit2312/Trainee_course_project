using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TraineeGame;

    public class StoneObstacle : MonoBehaviour, IObstacleType
    {
        [SerializeField] private GameObject _prefab;
        public GameObject GetObstacle()
        {
            GameObject stone = Instantiate(_prefab);
            return stone;
        }
    }

