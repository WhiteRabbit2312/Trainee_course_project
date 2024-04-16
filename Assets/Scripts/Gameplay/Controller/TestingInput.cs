using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInput : IMovement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Controller()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        
    }
}
