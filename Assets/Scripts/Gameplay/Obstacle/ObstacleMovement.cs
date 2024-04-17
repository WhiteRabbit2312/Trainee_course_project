using UnityEngine;

namespace TraineeGame
{
    public class ObstacleMovement : MonoBehaviour
    {
        private Vector3 _spawnLeft = new Vector3(-1.4f, 0f, 17f);
        private Vector3 _spawnCenter = new Vector3(0f, 0f, 17f);
        private Vector3 _spawnRight = new Vector3(1.4f, 0f, 17f);

        private const int DirVariant = 3;

        private Vector3 dirVector = new Vector3(0f, 0f, -1.4f);
        private ISpeedPlayer _speed;
        private bool _canMove = true;

        private void Awake()
        {
            GameManager.onEndGame += StopMove;
        }

        public void ApplySpeed(ISpeedPlayer speedPlayer)
        {
            _speed = speedPlayer;
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
            if(_canMove)
                MoveObstacle();
        }

        private void StopMove() => _canMove = false;

        private void MoveObstacle()
        {
            transform.Translate(dirVector.normalized * _speed.Speed * Time.deltaTime);
        }
    }
}
