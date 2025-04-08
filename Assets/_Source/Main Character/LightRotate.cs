using UnityEngine;

namespace _Source.Main_Character
{
    public class LightRotate : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            RotateTowardsMouse();
        }

        private void RotateTowardsMouse()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = Mathf.Abs(_mainCamera.transform.position.z); // или расстояние от камеры до объекта

            Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
            Vector2 direction = mouseWorldPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }
}
