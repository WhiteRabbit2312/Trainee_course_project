using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    private Vector3 _toLeft;
    private Vector3 _toCenter;
    private Vector3 _toRight;

    private const int DirVariant = 3;
    private float _spawnIncidence = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnObstacle()
    {
        var obstacle = Instantiate(gameObject);
        yield return new WaitForSeconds(_spawnIncidence);
    }

    private void MoveObstacle(GameObject obstacle)
    {
        int dirrection = Random.Range(0, DirVariant);
        Vector3 dirVector;

        switch (dirrection)
        {
            case 0: dirVector = _toLeft; break;
            case 1: dirVector = _toCenter; break;
            case 2: dirVector = _toRight; break;
        }


    }

   

}
