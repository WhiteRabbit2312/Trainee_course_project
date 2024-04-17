using UnityEngine;

namespace TraineeGame
{
    public class StoneObstacle : MonoBehaviour, IObstacleType
    {
        [SerializeField] private ObstacleMovement _prefab;
        public ObstacleMovement GetObstacle()
        {
            ObstacleMovement stone = Instantiate(_prefab);
            return stone;
        }
    }
}

