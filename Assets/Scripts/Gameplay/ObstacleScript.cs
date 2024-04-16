using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    private Vector3 _toLeft;
    private Vector3 _toCenter;
    private Vector3 _toRight;

    private const int DirVariant = 3;

    private void OnEnable()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        int dirrection = Random.Range(0, DirVariant);
        Vector3 dirVector = default;

        switch (dirrection)
        {
            case 0: dirVector = _toLeft; break;
            case 1: dirVector = _toCenter; break;
            case 2: dirVector = _toRight; break;
        }

        transform.position = Vector3.Lerp(_spawnPoint.position,
                dirVector, Time.deltaTime);
    }

   

}
