using UnityEngine;
using UnityEngine.InputSystem;

namespace _Source.Main_Character
{
    public class GameInput : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;
        public static GameInput Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Enable();
        }
    
        public Vector2 GetMovementVector()
        {
            Vector2 inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
            return inputVector;
        }

        public Vector3 GetMousePosition()
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            return mousePosition;
        }
        public Vector3 GetMouseWorldPosition()
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = Camera.main.nearClipPlane;
            return Camera.main.ScreenToWorldPoint(screenPos);
        }
    }
}
