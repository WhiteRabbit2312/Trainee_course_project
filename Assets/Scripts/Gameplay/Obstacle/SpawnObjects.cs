using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;

namespace TraineeGame
{
    public class SpawnObjects : MonoBehaviour, ISpeedPlayer
    {
        private const int PrefabNumber = 20;
        private const int ObstacleType = 2;

        private List<ObstacleMovement> _pool = new List<ObstacleMovement>();
        
        private IObstacleType _stoneObstacle;//
        private IObstacleType _gateObstacle;//

        private int counter = 10;
        private float _speed = 5f;
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }


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
               
                _obstacle.gameObject.SetActive(false);
                _pool.Add(_obstacle);

            }
        }

        private ObstacleMovement GetObstacleType(int type)
        {
            switch (type)
            {
                case 0:
                    var obst1 = _stoneObstacle.GetObstacle();
                    obst1.ApplySpeed(this);
                    return obst1;

                case 1: 
                    var obst2 = _gateObstacle.GetObstacle();
                    obst2.ApplySpeed(this);
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
                ObstacleMovement obstacle = GetObstacleFromPool();
                if (obstacle != null)
                {
                    obstacle.gameObject.SetActive(true);
                    counter++;

                    if(counter % 20 == 0)
                    {

                        Speed += 2;
                        
                    }
                }
                yield return new WaitForSeconds(1f);
            }

        }

        private ObstacleMovement GetObstacleFromPool()
        {
            for (int i = 0; i < _pool.Count; ++i)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                {
                    return _pool[i];
                }
            }

            return null;
        }
    }
}
