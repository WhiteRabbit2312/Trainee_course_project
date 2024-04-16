using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawner;
    private List<GameObject> _pool;
    private readonly int _prefabNumber = 10;
    private int spawnIncidence = 2000;

    private void Awake()
    {
        for(int i = 0; i < _prefabNumber; ++i)
        {
            var _obstacle = Instantiate(_prefab);
            _obstacle.SetActive(false);
            _pool.Add(_obstacle);
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
            obstacle.transform.position = _spawner.position;
            obstacle.SetActive(true);
        }
        await Task.Delay(spawnIncidence);

    }

    private GameObject GetObstacle()
    {
        for(int i = 0; i < _pool.Count; ++i)
        {
            if (!_pool[i].activeInHierarchy)
            {
                return _pool[i];
            }
        }

        return null;
    }
}
