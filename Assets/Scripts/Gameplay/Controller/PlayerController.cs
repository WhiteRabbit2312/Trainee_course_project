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

        private Vector3 _idlePlayerPosition;
        private Vector3 _leftPlayerPosition;
        private Vector3 _rightPlayerPosition;
        private PlayerRunPosition _state;

        private void Awake()
        {
#if UNITY_EDITOR

            _input = new MainInput();

#elif UNITY_ANDROID
        _input = new MainInput();
#endif

        }

        private enum PlayerRunPosition
        {
            Left,
            Center,
            Right
        }

        // Start is called before the first frame update
        void Start()
        {
            _state = PlayerRunPosition.Center;
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

            else
            {
                Idle();
            }
        }

      

        private void Idle()
        {
            transform.position = _idlePlayerPosition;
            onPlayerIdle?.Invoke();
        }

        private void Jump()
        {
            onPlayerJump?.Invoke();
        }

        private void Slide()
        {
            onPlayerSlide?.Invoke();
        }

        private void Left()
        {
            if (_state == PlayerRunPosition.Center)
            {
                transform.position = Vector3.Lerp(_idlePlayerPosition,
                    _leftPlayerPosition, Time.deltaTime);
                _state = PlayerRunPosition.Left;
                return;
            }

            else if (_state == PlayerRunPosition.Right)
            {
                transform.position = Vector3.Lerp(_rightPlayerPosition,
                    _idlePlayerPosition, Time.deltaTime);

                _state = PlayerRunPosition.Center;
            }
        }



        private void Right()
        {
            if (_state == PlayerRunPosition.Left)
            {
                transform.position = Vector3.Lerp(_leftPlayerPosition,
                    _idlePlayerPosition, Time.deltaTime);

                _state = PlayerRunPosition.Center;
                return;
            }

            else if (_state == PlayerRunPosition.Center)
            {
                transform.position = Vector3.Lerp(_idlePlayerPosition,
                    _rightPlayerPosition, Time.deltaTime);
                _state = PlayerRunPosition.Right;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Obstacle")
            {
                GameManager.State = GameState.EndGame;
            }
        }
    }
}