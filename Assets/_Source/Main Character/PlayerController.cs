using System;
using UnityEngine;

namespace _Source.Main_Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private GameObject flashLight;

        private Rigidbody2D rb;

        private void Awake()
        {
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
            Vector2 inputVector = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.W))
            {
                inputVector.y = 1f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                inputVector.y = -1f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                inputVector.x = -1f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                inputVector.x = 1f;
            }

            inputVector = inputVector.normalized;
            
            rb.MovePosition(rb.position + inputVector * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}
