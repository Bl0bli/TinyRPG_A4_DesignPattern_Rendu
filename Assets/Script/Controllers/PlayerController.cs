using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private InputActionReference _iaMove;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _visualTransform;

    private PlayerStats _stats;

    [SerializeField] private float _lerpRotationSpeed = 10f;
    
    Vector3 _moveDirection;
    
    public event Action<float> OnMove;

    private void OnEnable()
    {
        _iaMove.action.performed += HandleMove;
        _iaMove.action.canceled += HandleMove;
        
        _iaMove.action.Enable();
    }

    private void OnDisable()
    {
        _iaMove.action.performed -= HandleMove;
        _iaMove.action.canceled -= HandleMove;
        
        _iaMove.action.Disable();
    }

    private void Start() {
        _stats = Resources.Load<PlayerStats>("PlayerStats");
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        Vector2 ctx = context.ReadValue<Vector2>();
        _moveDirection = new Vector3(ctx.x, 0, ctx.y);
        OnMove?.Invoke(_moveDirection.magnitude > 0 ? 1f : 0f);
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        _rb.linearVelocity = _moveDirection * (_stats.CurrentSpeed * Time.fixedDeltaTime);
        if (_moveDirection.sqrMagnitude > 0)
        {
            _visualTransform.forward = Vector3.Lerp(_visualTransform.forward, _moveDirection, Time.fixedDeltaTime * _lerpRotationSpeed);
        }
    }
}
