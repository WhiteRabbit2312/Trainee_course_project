using UnityEngine;

namespace TraineeGame
{
    public class StoneObstacle : MonoBehaviour, IObstacleType
    {
        [SerializeField] private ObstacleMovement _prefab;
        //TODO: Create class without monobehaviour 
        //public StoneObstacle(ObstacleMovement obstacle)
        //{
        //    _prefab = obstacle;
        //}
       
        public ObstacleMovement GetObstacle()
        {
            ObstacleMovement stone = Instantiate(_prefab);
            return stone;
        }
    }
}

