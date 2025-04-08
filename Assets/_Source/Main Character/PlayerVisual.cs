using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Main_Character;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;
    private const string IsRunning = "IsRunning";
    private const string LookX = "LookX"; // Направление взгляда по X
    private const string LookY = "LookY"; // Направление взгляда по Y
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetBool(IsRunning, PlayerController.Instance.IsRunning());
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mouseScreenPosition = GameInput.Instance.GetMousePosition();
        Vector3 playerScreenPosition = PlayerController.Instance.GetPlayerScreenPosition();
        
        Vector2 lookDirection = (mouseScreenPosition - playerScreenPosition).normalized;

        // Передаем направление в аниматор
        _animator.SetFloat(LookX, lookDirection.x);
        _animator.SetFloat(LookY, lookDirection.y);
    }
}
