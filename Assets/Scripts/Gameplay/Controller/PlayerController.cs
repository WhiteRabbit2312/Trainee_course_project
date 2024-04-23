using System.Collections;
using UnityEngine;
using System;

namespace TraineeGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;

        private float _groundCheckDistance = 1f;
        private IMovement _input;
        public static event Action onPlayerIdle;
        public static Action onPlayerJump;
        public static Action onPlayerRun;
        public static Action onPlayerSlide;

        private float _centerPosX = 0f;
        private float _leftPosX = -1.4f;
        private float _rightPosX = 1.4f;

        private PlayerPos _playerPos;
        private Rigidbody _rb;
        private float jumpForce = 6f;
        private bool _isGrounded = true;
        private bool _canControl = false;
        private CapsuleCollider _collider;
       
        private void Awake()
        {
#if UNITY_EDITOR

            _input = GetComponent<TestingInput>();

#elif UNITY_ANDROID
        _input = GetComponent<MainInput>();
#endif
            _playerPos = PlayerPos.Center;
            _rb = GetComponent<Rigidbody>();
            _collider = GetComponent<CapsuleCollider>();
            GameManager.onPreGame += Idle;
            GameManager.onPreGame += StopControl;
            GameManager.onGameplay += CanControl;
            GameManager.onEndGame += StopControl;
        }

        void Update()
        {
            if (_canControl)
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
                    if (_isGrounded)
                        Jump();
                }

                else if (_input.GoDown())
                {
                    Slide();
                }
            }
        }

        private void CanControl() => _canControl = true;
        private void StopControl() => _canControl = false;

        private void Idle()
        {
            transform.position = Vector3.zero;
        }

        private void Jump()
        {
            onPlayerJump?.Invoke();
            
            if(CheckGround())
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private bool CheckGround()
        {
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance, _groundLayer);
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
            Debug.Log("Is left");

            StopCoroutine(ChangePosition());

            if (_playerPos == PlayerPos.Center)
            {
                StartCoroutine(ChangePosition(_leftPosX));

                _playerPos = PlayerPos.Left;
            }

            else if (_playerPos == PlayerPos.Right)
            {
                StartCoroutine(ChangePosition(_centerPosX));
                _playerPos = PlayerPos.Center;
            }
        }

        private IEnumerator ChangePosition(float newX = 0)
        {
            float t = 0f;
            Vector3 startPos = transform.position;
            while (transform.position.x != newX)
            {
                t += Time.deltaTime * 10f;
                transform.position = Vector3.Lerp(startPos,
                    new Vector3(newX, transform.position.y, transform.position.z), t);
                yield return new WaitForEndOfFrame();
            }

        }

        private void Right()
        {
            Debug.Log("Is right");

            StopCoroutine(ChangePosition());
            if (_playerPos == PlayerPos.Center)
            {
                StartCoroutine(ChangePosition(_rightPosX));

                _playerPos = PlayerPos.Right;
            }

            else if (_playerPos == PlayerPos.Left)
            {
                StartCoroutine(ChangePosition(_centerPosX));

                _playerPos = PlayerPos.Center;
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Obstacle")
            {
                Death();
            }
        }

        private void Death()
        {
            GameManager.GameOver();
        }

        private void OnDestroy()
        {
            
        }
    }
}