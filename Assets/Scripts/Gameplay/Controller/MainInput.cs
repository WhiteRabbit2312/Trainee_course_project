using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TraineeGame
{
    public class MainInput : MonoBehaviour, IMovement
    {
        private Vector3 startTouchPosition;
        private Vector3 endTouchPosition;

        private bool swipeUp;
        private bool swipeDown;
        private bool swipeLeft;
        private bool swipeRight;

        void Update()
        {
            Controller();
        }

        public void Controller()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    startTouchPosition = touch.position;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    endTouchPosition = touch.position;
                }
            }

            DetectSwipe();
        }

        private void DetectSwipe()
        {
            float swipeDistanceThreshold = 50f;

            Vector2 swipeDirection = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(swipeDirection.x) > swipeDistanceThreshold ||
                Mathf.Abs(swipeDirection.y) > swipeDistanceThreshold)
            {
                if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                {


                    if (swipeDirection.x > 0)
                    {
                        swipeRight = true;
                    }
                    else
                    {
                        swipeLeft = true;
                    }
                }
                else
                {
                    if (swipeDirection.y > 0)
                    {
                        swipeUp = true;
                    }
                    else
                    {
                        swipeDown = true;
                    }
                }
            }
        }

        public bool GoUp()
        {
            if (swipeUp)
            {
                swipeUp = false;
                return true;
            }
            return false;
        }

        public bool GoDown()
        {
            if (swipeDown)
            {
                swipeDown = false;
                return true;
            }
            return false;
        }

        public bool GoRight()
        {
            if (swipeRight)
            {
                swipeRight = false;
                return true;
            }
            return false;
        }

        public bool GoLeft()
        {
            if (swipeLeft)
            {
                swipeLeft = false;
                return true;
            }
            return false;
        }
    }
}
