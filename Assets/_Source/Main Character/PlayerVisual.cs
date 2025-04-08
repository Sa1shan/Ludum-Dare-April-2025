using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace _Source.Main_Character
{
    public class PlayerVisual : MonoBehaviour
    {
        [SerializeField] private GameObject flashlight;
        [SerializeField] private Light2D playerLight;
        private Animator _animator;
        private const string IsRunning = "IsRunning";
        private const string LookX = "LookX";
        private const string LookY = "LookY";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(IsRunning, PlayerController.Instance.IsRunning());
            AdjustPlayerFacingDirection();

            if (flashlight.activeSelf)
            {
                playerLight.intensity = 0.1f;
            }
            else
            {
                playerLight.intensity = 0.02f;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (flashlight != null)
                {
                    
                    var isActive = flashlight.activeSelf;
                    flashlight.SetActive(!isActive);
                    
                }
            }
        }

        private void AdjustPlayerFacingDirection()
        {
            Vector3 mouseWorldPosition = GameInput.Instance.GetMouseWorldPosition();
            Vector3 playerWorldPosition = PlayerController.Instance.transform.position;

            Vector2 lookDirection = (mouseWorldPosition - playerWorldPosition).normalized;

            _animator.SetFloat(LookX, lookDirection.x);
            _animator.SetFloat(LookY, lookDirection.y);
        }
    }
}