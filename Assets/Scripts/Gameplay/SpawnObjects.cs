using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawner;
    private List<GameObject> _pool;
    private readonly int _prefabNumber = 10;

    private void Awake()
    {
        for(int i = 0; i < _prefabNumber; ++i)
        {
            var _obstacle = Instantiate(_prefab);
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
        
    }

    private GameObject GetObstacle()
    {
        //var obstacle = _pool.FirstOrDefault(_prefab => _prefab.isStatic);
        return null;
    }
}
