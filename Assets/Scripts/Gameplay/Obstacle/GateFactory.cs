using UnityEngine;

namespace TraineeGame
{
    public class GateFactory : MonoBehaviour, IObstacleType // GateFactory
    {
        [SerializeField] private ObstacleMovement _prefab;


        public ObstacleMovement GetObstacle() //CreateObstacle
        {
            ObstacleMovement gate = Instantiate(_prefab);
            return gate;
        }
    }
}
