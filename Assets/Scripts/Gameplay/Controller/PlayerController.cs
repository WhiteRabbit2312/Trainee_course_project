using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovement _input;

    private void Awake()
    {
#if UNITY_EDITOR

        _input = new TestingInput();

#elif UNITY_ANDROID
        _input = new MainInput();
#endif

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
