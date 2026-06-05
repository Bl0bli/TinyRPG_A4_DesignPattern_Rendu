using System;
using System.Collections;
using UnityEngine;

public class Arrow : Poolable
{
    [Header("References")] 
    [SerializeField] private Rigidbody _rb;
    
    [Header("Params")]
    [SerializeField] private int _damage = 1;
    
    override public void Init(Vector3 position, Quaternion rotation,Vector3 direction)
    {
        transform.position = position;
        transform.rotation = rotation;
        if(_rb != null) _rb.AddRelativeForce(direction);
        
        base.Init(position, rotation, direction);
    }

    protected override IEnumerator LifeTimeRoutine()
    {
        yield return base.LifeTimeRoutine();
        Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealth health))
        {
            health.TakeDamage(_damage);
        }
        Disable();
    }

    private void Disable()
    {
        if (_rb != null)
        {
            _rb.linearVelocity = Vector3.zero;
        }
        SetActive(false);
    }
}
