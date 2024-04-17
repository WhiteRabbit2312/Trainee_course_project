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
        public static Action onPlayerIdle;
        public static Action onPlayerJump;
        public static Action onPlayerRun;
        public static Action onPlayerSlide;

        private Vector3 _idlePlayerPosition = new Vector3(0f, 0f, 0f);
        private Vector3 _leftPlayerPosition = new Vector3(-1.4f, 0f, 0f);
        private Vector3 _rightPlayerPosition = new Vector3(1.4f, 0f, 0f);

        private PlayerPos playerPos;
        private Rigidbody rb;
        private float jumpForce = 6f;
        private bool _isGrounded = true;
        private CapsuleCollider _collider;
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
            _collider = GetComponent<CapsuleCollider>();
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
                if(_isGrounded)
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
            
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
            if(isGrounded)
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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