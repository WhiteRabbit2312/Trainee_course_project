using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraineeGame
{
    public class SpawnObjects : MonoBehaviour, ISpeedPlayer
    {
        [SerializeField] private ObstacleMovement _prefabStone;
        [SerializeField] private ObstacleMovement _prefabGate;
        private const int PrefabNumber = 20; //PrefabCount
        private const int ObstacleType = 2; //MaxPbstacleCount

        private List<ObstacleMovement> _pool = new List<ObstacleMovement>();
        
        private IObtacleFactory _stoneObstacle;
        private IObtacleFactory _gateObstacle;

        private int counter = 10;
        private float _speed = 5f;
        private bool _isGameplay = true;


        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }


        private void Awake()
        {
            _stoneObstacle = new StoneFactory(_prefabStone);
            _gateObstacle = new GateFactory(_prefabGate);

            GameManager.onGameplay += CanPlay;
            GameManager.onEndGame += StopPlay;
          
        }

        private void Start()
        {
            for (int i = 0; i < PrefabNumber; ++i)
            {
                int obstacleType = Random.Range(0, ObstacleType);
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
                    var obst1 = _stoneObstacle.CreateObstacle();
                    obst1.ApplySpeed(this);
                    return obst1;

                case 1: 
                    var obst2 = _gateObstacle.CreateObstacle();
                    obst2.ApplySpeed(this);
                    return obst2;

                default: return null;
            }
        }

        private void CanPlay() 
        {
            _isGameplay = true;
            StartCoroutine(SpawnObstacle()); 
        }
        private void StopPlay()
        {
            _isGameplay = false;
            DisableObstacles();
        }
            

        private IEnumerator SpawnObstacle()
        {
            while (_isGameplay)
            {
                ObstacleMovement obstacle = GetObstacleFromPool();
                if (obstacle != null)
                {
                    obstacle.gameObject.SetActive(true);
                    counter++;

                    if(counter % 20 == 0)
                    {
                        Speed += 1; 
                    }
                }
                yield return new WaitForSeconds(1.5f);
            }

        }



        private void DisableObstacles()
        {
            foreach(var item in _pool)
            {
                item.gameObject.SetActive(false);
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
