using UnityEngine;

namespace TraineeGame
{
    public class StoneFactory: IObtacleFactory
    {
        private ObstacleMovement _prefab;
        //TODO: Create class without monobehaviour 
        public StoneFactory(ObstacleMovement obstacle)
        {
            _prefab = obstacle;
        }
       
        public ObstacleMovement CreateObstacle()
        {
            ObstacleMovement stone = GameObject.Instantiate(_prefab);
            return stone;
        }
    }
}

