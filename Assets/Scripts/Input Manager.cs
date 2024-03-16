using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.WalkingActions _movement;
    private PlayerController _playerController;
    private PlayerLook _playerLook;
    
    void Awake()
    {
        _playerInput = new PlayerInput();
        _movement = _playerInput.walking;
        
        _playerController = GetComponent<PlayerController>();
        _movement.Jumping.performed += ctx => _playerController.Jump(); // Pass ctx to the Jump method

        _playerLook = GetComponent<PlayerLook>();
    }

    void FixedUpdate()
    {
        _playerController.Move(_movement.Moving.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _playerLook.LookManagement(_movement.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _movement.Enable();
    }

    private void OnDisable()
    {
        _movement.Disable();
    }
}