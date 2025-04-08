using System;
using UnityEngine;

namespace _Source.Main_Character
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { get; private set; }
        
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private GameObject flashLight;
        private float _minMovingSpeed = 0.1f;
        private bool _isRunning = false;
        private Rigidbody2D rb;
        private void Awake()
        {
            Instance = this;
            rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                flashLight.SetActive(!flashLight.activeSelf);
            }
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector2 inputVector = GameInput.Instance.GetMovementVector();
            inputVector = inputVector.normalized;
            rb.MovePosition(rb.position + inputVector * (moveSpeed * Time.fixedDeltaTime));

            if (Math.Abs(inputVector.x) > _minMovingSpeed || MathF.Abs(inputVector.y) > _minMovingSpeed)
            {
                _isRunning = true;
            }
            else
            {
                _isRunning = false;
            }
        }

        public bool IsRunning()
        {
            return _isRunning;
        }

        public Vector3 GetPlayerScreenPosition()
        {
            Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
            return playerScreenPosition;
        }
    }
}
