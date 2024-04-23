using UnityEngine;

namespace TraineeGame
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            GameManager.onEndGame += StayAnimation;

            PlayerController.onPlayerJump += JumpAnimation;
            PlayerController.onPlayerRun += RunAnimation;
            PlayerController.onPlayerSlide += SlideAnimation;

            GameManager.onGameplay += RunAnimation;
        }

        private void StayAnimation()
        {
            animator.SetBool("Run", false);
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

        private void OnDestroy()
        {
            GameManager.onEndGame -= StayAnimation;

            PlayerController.onPlayerJump -= JumpAnimation;
            PlayerController.onPlayerRun -= RunAnimation;
            PlayerController.onPlayerSlide -= SlideAnimation;

            GameManager.onGameplay -= RunAnimation;
        }
    }
}