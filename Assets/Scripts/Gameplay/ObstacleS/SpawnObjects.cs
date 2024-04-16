using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace TraineeGame
{
    public class SpawnObjects : MonoBehaviour
    {
        private List<GameObject> _pool;
        private const int PrefabNumber = 10;
        private const int ObstacleType = 2;
        private int spawnIncidence = 2000;

        private void Awake()
        {
            for (int i = 0; i < PrefabNumber; ++i)
            {
                int obstacleType = Random.Range(0, ObstacleType);
                var _obstacle = GetObstacleType(obstacleType);
                _obstacle.SetActive(false);
                _pool.Add(_obstacle);
            }
        }

        private GameObject GetObstacleType(int type)
        {
            switch (type)
            {
                case 0: return new StoneObstacle().GetObstacle();
                case 1: return new GateObstacle().GetObstacle(); 
                default: return null;
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            SpawnObstacle();
        }

        async void SpawnObstacle()
        {
            GameObject obstacle = GetObstacle();
            if (obstacle != null)
            {
                obstacle.transform.position = transform.position;
                obstacle.SetActive(true);
            }
            await Task.Delay(spawnIncidence);

        }

        private GameObject GetObstacle()
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
