using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{    
    public enum ChaserStatus
    {
        Stop,
        Idle,
        Left,
        Right,
    }
    
    public class ChaserEngine : MonoBehaviour
    {
        public CharacterAnimator character;
        
        [Header("speed data")]
        public float speed;
        public float targetSpeed;
        public ChaserStatus state;
        public float minSpeed;
//        public float maxSpeed;
        public float slowDownRate;
        public float speedIncreaseStep;
        public float speedSmooth;
        
        private void Awake()
        {
            state = ChaserStatus.Stop;
            speed = 0;
        }

        private void Update()
        {
            HandleInput();
            HandleDrag();
            HandleSpeed();
        }

        /*
         *
         *    Private methods
         * 
         */

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveRight();
            }
        }

        private void MoveLeft()
        {
            switch (state)
            {
                case ChaserStatus.Idle:
                    state = ChaserStatus.Left;
                    break;
                case ChaserStatus.Right:
                    MoveForward();
                    state = ChaserStatus.Right;
                    break;
            }
        }

        private void MoveRight()
        {
            switch (state)
            {
                case ChaserStatus.Idle:
                    state = ChaserStatus.Right;
                    break;
                case ChaserStatus.Left:
                    MoveForward();
                    state = ChaserStatus.Left;
                    break;
            }
        }

        private void MoveForward()
        {
            targetSpeed += speedIncreaseStep;
        }

        private void HandleDrag()
        {
            targetSpeed -= slowDownRate;
            targetSpeed = Mathf.Max(targetSpeed, minSpeed);
        }
        
        private void HandleSpeed()
        {
//            speed = Mathf.SmoothStep(speed, targetSpeed, Time.deltaTime * speedSmooth);
            speed = 2;
        }
    }
}