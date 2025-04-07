using System;
using UnityEngine;

namespace _Source.Main_Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private GameObject flashLight;
        private PlayerInputActions _playerInputActions;
        private Rigidbody2D rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Enable();
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
            Vector2 inputVector = GameInput.Instance.GetMovementVector();
            inputVector = inputVector.normalized;
            rb.MovePosition(rb.position + inputVector * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}
