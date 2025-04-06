using UnityEngine;

namespace _Source.Main_Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float xAngle = 1f;
        [SerializeField] private float yAngle = 0.5f;
        [SerializeField] private GameObject flashLight;

        private Rigidbody2D rb;
        private Vector2 moveInput;
        private Vector2 moveDirection;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            moveInput = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveInput += new Vector2(xAngle, yAngle);
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveInput += new Vector2(-xAngle, -yAngle);
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveInput += new Vector2(-xAngle, yAngle);
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveInput += new Vector2(xAngle, -yAngle);
            }

            moveInput = moveInput.normalized;
        }

        private void FixedUpdate()
        {
            rb.velocity = moveInput * moveSpeed;
        }
    }
}
