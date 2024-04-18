using System.Collections;
using UnityEngine;
using System;

namespace TraineeGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Animation _animation;

        private float groundCheckDistance = 1f;
        private IMovement _input;
        public static event Action onPlayerIdle;
        public static Action onPlayerJump;
        public static Action onPlayerRun;
        public static Action onPlayerSlide;

        private float _centerPosX = 0f;
        private float _leftPosX = -1.4f;
        private float _rightPosX = 1.4f;

        private PlayerPos playerPos;
        private Rigidbody rb;
        private float jumpForce = 6f;
        private bool _isGrounded = true;
        private CapsuleCollider _collider;
       
        private void Awake()
        {
#if UNITY_EDITOR

            _input = GetComponent<TestingInput>();

#elif UNITY_ANDROID
        _input = new MainInput();
#endif
            playerPos = PlayerPos.Center;
            rb = GetComponent<Rigidbody>();
            _collider = GetComponent<CapsuleCollider>();
            GameManager.onPreGame += Idle;
        }

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
                if(_isGrounded)
                    Jump();
            }

            else if (_input.GoDown())
            {
                Slide();
            }
        }

        private void Idle()
        {
            transform.position = Vector3.zero;
        }

        private void Jump()
        {
            onPlayerJump?.Invoke();
            
            if(CheckGround())
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private bool CheckGround()
        {
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
            return isGrounded;
        }

        private void Slide()
        {
            onPlayerSlide?.Invoke();

            StartCoroutine(ChangeColliderSize());  
        }

        private IEnumerator ChangeColliderSize()// TODO
        {
            _collider.height = 0.9f;
            _collider.center = new Vector3(0f, 0.47f, 0f);

            yield return new WaitForSeconds(1f);
            _collider.height = 2f;
            _collider.center = new Vector3(0f, 1f, 0f);
        }

        private void Left()
        {
            if (playerPos == PlayerPos.Center)
            {
                transform.position = new Vector3(_leftPosX, transform.position.y, transform.position.z);
                playerPos = PlayerPos.Left;
            }

            else if (playerPos == PlayerPos.Right)
            {
                transform.position = new Vector3(_centerPosX, transform.position.y, transform.position.z);
                playerPos = PlayerPos.Center;
            }

            else return;
        }

        private void Right()
        {
            if (playerPos == PlayerPos.Center)
            {
                transform.position = new Vector3(_rightPosX, transform.position.y, transform.position.z);
                playerPos = PlayerPos.Right;
            }

            else if (playerPos == PlayerPos.Left)
            {
                transform.position = new Vector3(_centerPosX, transform.position.y, transform.position.z);

                playerPos = PlayerPos.Center;
            }

            else return;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Obstacle")
            {
                Deatn();
            }
        }

        private void Deatn()
        {
            GameManager.GameOver();
        }
    }
}