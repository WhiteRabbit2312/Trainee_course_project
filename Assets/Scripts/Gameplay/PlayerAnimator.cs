using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraineeGame
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            PlayerController.onPlayerIdle += StayAnimation;
            PlayerController.onPlayerJump += JumpAnimation;
            PlayerController.onPlayerRun += RunAnimation;
            PlayerController.onPlayerSlide += SlideAnimation;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void StayAnimation()
        {
            animator.SetBool("Stay", true);
        }

        private void JumpAnimation()
        {
            animator.SetBool("Jump", true);
        }

        private void RunAnimation()
        {
            animator.SetBool("Run", true);
        }

        private void SlideAnimation()
        {
            animator.SetBool("Slide", true);
        }
    }
}