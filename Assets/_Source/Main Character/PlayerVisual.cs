using _Source.Main_Character;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;
    private const string IsRunning = "IsRunning";
    private const string LookX = "LookX";
    private const string LookY = "LookY";
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _flashlightTransform;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _flashlightTransform = _flashlightTransform.transform;
    }

    private void Update()
    {
        _animator.SetBool(IsRunning, PlayerController.Instance.IsRunning());
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mouseWorldPosition = GameInput.Instance.GetMouseWorldPosition(); // <--- добавим такой метод
        Vector3 playerWorldPosition = PlayerController.Instance.transform.position;

        Vector2 lookDirection = (mouseWorldPosition - playerWorldPosition).normalized;

        _animator.SetFloat(LookX, lookDirection.x);
        _animator.SetFloat(LookY, lookDirection.y);

        if (_flashlightTransform != null)
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            _flashlightTransform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}