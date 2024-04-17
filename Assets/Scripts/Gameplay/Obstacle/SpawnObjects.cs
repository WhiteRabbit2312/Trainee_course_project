using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

namespace TraineeGame
{
    public class SpawnObjects : MonoBehaviour
    {
        private const int PrefabNumber = 20;
        private const int ObstacleType = 2;

        private List<GameObject> _pool = new List<GameObject>();
        
        private StoneObstacle _stoneObstacle;
        private GateObstacle _gateObstacle;

        private void Awake()
        {
            _stoneObstacle = GetComponent<StoneObstacle>();
            _gateObstacle = GetComponent<GateObstacle>();

            GameManager.onGameplay += CanPlay;
            GameManager.onEndGame += StopPlay;
        }

        private void Start()
        {
            for (int i = 0; i < PrefabNumber; ++i)
            {
                int obstacleType = UnityEngine.Random.Range(0, ObstacleType);
                var _obstacle = GetObstacleType(obstacleType);
               
                _obstacle.SetActive(false);
                _pool.Add(_obstacle);

            }
        }

        private GameObject GetObstacleType(int type)
        {
            switch (type)
            {
                case 0:
                    var obst1 = _stoneObstacle.GetObstacle();
                    return obst1;

                case 1: 
                    var obst2 = _gateObstacle.GetObstacle();
                    return obst2;

                default: return null;
            }
        }

        private void CanPlay() => StartCoroutine(SpawnObstacle());
        private void StopPlay() => StopCoroutine(SpawnObstacle());

        private IEnumerator SpawnObstacle()
        {
            while (true)
            {
                GameObject obstacle = GetObstacleFromPool();
                if (obstacle != null)
                {
                    //obstacle.transform.position = transform.position;
                    obstacle.SetActive(true);
                }
                yield return new WaitForSeconds(1f);

            }

        }

        private GameObject GetObstacleFromPool()
        {
            for (int i = 0; i < _pool.Count; ++i)
            {
                if (!_pool[i].activeInHierarchy)
                {
                    return _pool[i];
                }
            }

            return null;
        }
    }
}
