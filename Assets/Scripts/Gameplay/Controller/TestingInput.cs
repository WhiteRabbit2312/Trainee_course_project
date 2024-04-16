using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInput : MonoBehaviour, IMovement
{
    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
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
        if (Input.GetKey(KeyCode.A)) moveLeft = true;
        if (Input.GetKey(KeyCode.D)) moveRight = true;
        if (Input.GetKey(KeyCode.W)) moveUp = true;
        if (Input.GetKey(KeyCode.S)) moveDown = true;
    }

    public bool GoLeft()
    {
        if (moveLeft)
        {
            moveLeft = false;
            return true;
        }
        return false;
    }

    public bool GoRight()
    {
        if (moveRight)
        {
            moveRight = false;
            return true;
        }
        return false;
    }

    public bool GoUp()
    {
        if (moveUp)
        {
            moveUp = false;
            return true;
        }
        return false;
    }

    public bool GoDown()
    {
        if (moveDown)
        {
            moveDown = false;
            return true;
        }
        return false;
    }
}
