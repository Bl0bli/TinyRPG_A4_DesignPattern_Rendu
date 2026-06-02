using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private InputActionReference _iaMove;
    [SerializeField] private InputActionReference _iaAttack;
    [SerializeField] private Rigidbody _rb;

    [Header("Params")] 
    [SerializeField] private float _speed = 1f;
    
    Vector2 _moveDirection;

    private void OnEnable()
    {
        _iaMove.action.performed += HandleMove;
        _iaMove.action.canceled += HandleMove;
        _iaAttack.action.started += HandleAttack;
        _iaAttack.action.canceled += HandleAttack;
        
        _iaMove.action.Enable();
        _iaAttack.action.Enable();
    }

    private void OnDisable()
    {
        _iaMove.action.performed -= HandleMove;
        _iaMove.action.canceled -= HandleMove;
        _iaAttack.action.started -= HandleAttack;
        _iaAttack.action.canceled -= HandleAttack;
        
        _iaMove.action.Disable();
        _iaAttack.action.Disable();
    }
    
    private void HandleMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    private void HandleAttack(InputAction.CallbackContext context)
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        _rb.linearVelocity += (Vector3)_moveDirection * (_speed * Time.fixedDeltaTime);
        Debug.Log($"dir {_moveDirection} | speed {_speed} | velocity {_rb.linearVelocity} | time {Time.fixedDeltaTime} | calc {(Vector3)_moveDirection * (_speed * Time.fixedDeltaTime)}");
    }
}
