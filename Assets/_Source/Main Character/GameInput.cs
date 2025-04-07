using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
