using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraineeGame
{
    public class ObstacleMovement : MonoBehaviour
    {
        private Vector3 _spawnLeft = new Vector3(-2f, 0f, 17f);
        private Vector3 _spawnCenter = new Vector3(0f, 0f, 17f);
        private Vector3 _spawnRight = new Vector3(2f, 0f, 17f);

        private const int DirVariant = 3;
       
        private float speed = 5f;
        private Vector3 dirVector = new Vector3(0f, 0f, -1.4f);

        private void Awake()
        {

        }

        private void OnEnable()
        {
            int spawner = Random.Range(0, DirVariant);
            switch (spawner)
            {
                case 0: transform.position = _spawnLeft; break;
                case 1: transform.position = _spawnCenter; break;
                case 2: transform.position = _spawnRight; break;
            }

        }

        void Update()
        {
            MoveObstacle();
        }

        private void MoveObstacle()
        {
            transform.Translate(dirVector.normalized * speed * Time.deltaTime);
        }
    }
}
