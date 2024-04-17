using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TraineeGame
{
    public class PlayerController : MonoBehaviour
    {
        private IMovement _input;
        public static Action onPlayerIdle;
        public static Action onPlayerJump;
        public static Action onPlayerRun;
        public static Action onPlayerSlide;

        private Vector3 _idlePlayerPosition = new Vector3(0f, 0f, 0f);
        private Vector3 _leftPlayerPosition = new Vector3(-1.4f, 0f, 0f);
        private Vector3 _rightPlayerPosition = new Vector3(1.4f, 0f, 0f);

        private PlayerPos playerPos;
        private Rigidbody rb;
        private float jumpForce = 4f;

        private enum PlayerPos
        {
            Left, 
            Center,
            Right
        }

        private void Awake()
        {
#if UNITY_EDITOR

            _input = GetComponent<TestingInput>();

#elif UNITY_ANDROID
        _input = new MainInput();
#endif
            playerPos = PlayerPos.Center;
            rb = GetComponent<Rigidbody>();
        }


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (_input.GoLeft())
            {
                Left();
            }

            else if (_input.GoRight())
            {
                Right();
            }

            else if (_input.GoUp())
            {
                Jump();
            }

            else if (_input.GoDown())
            {
                Slide();
            }
        }


        private void Jump()
        {
            onPlayerJump?.Invoke();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private void Slide()
        {
            onPlayerSlide?.Invoke();
        }

        private void Left()
        {
            if (playerPos == PlayerPos.Center)
            {
                transform.position = _leftPlayerPosition;
                playerPos = PlayerPos.Left;
            }

            else if (playerPos == PlayerPos.Right)
            {
                transform.position = _idlePlayerPosition;
                playerPos = PlayerPos.Center;
            }

            else return;
        }



        private void Right()
        {
            if (playerPos == PlayerPos.Center)
            {
                transform.position = _rightPlayerPosition;
                playerPos = PlayerPos.Right;
            }

            else if (playerPos == PlayerPos.Left)
            {
                transform.position = _idlePlayerPosition;

                playerPos = PlayerPos.Center;
            }

            else return;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Obstacle")
            {
                GameManager.onEndGame?.Invoke();
            }
        }
    }
}