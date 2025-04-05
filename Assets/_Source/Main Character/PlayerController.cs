using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float xAngle;
    public float yAngle;
    private Vector3 moveDirection;

    void Update()
    {
        moveDirection = Vector3.zero;

        // Управление на WASD или стрелки
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += new Vector3(xAngle, yAngle, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // Назад (вниз по изо)
            moveDirection += new Vector3(-xAngle, -yAngle, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // Влево (влево по изо)
            moveDirection += new Vector3(-xAngle, yAngle, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Вправо (вправо по изо)
            moveDirection += new Vector3(xAngle, -yAngle, 0);
        }

        moveDirection.Normalize(); // Чтобы скорость была одинаковая по диагонали

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
