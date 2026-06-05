using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private BoxCollider _collider;

    [SerializeField] private string _poolableID;
    [Header("Params")]
    [SerializeField] private Vector3 _shootDirection;
    [SerializeField] private float _speed = 50f;
    [SerializeField] private bool _loopShooting = false;
    [SerializeField, ShowIf("_loopShooting")] private float _shootInterval = 1f;

    private ObjectPooling _pooling;
    private Coroutine _coolDownRoutine;

    private void OnValidate()
    {
        if(_shootDirection == Vector3.zero) _shootDirection = transform.right;
    }

    void Start()
    {
        _pooling = PoolingServiceLocator.GetService(_poolableID);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_loopShooting) return;

        if (other.CompareTag("Player")) Shoot();
    }
    
    private void Shoot()
    {
        if (_pooling == null)
        {
            Debug.LogError($"Poolable {_poolableID} not found");
            return;
        }
        if(_coolDownRoutine != null) return;
        _pooling.GetPoolable().Init(transform.position, Quaternion.identity, _shootDirection * _speed);
        _coolDownRoutine = StartCoroutine(CoolDownRoutine());
    }

    private void FixedUpdate()
    {
        if (_loopShooting) Shoot();
    }

    private IEnumerator CoolDownRoutine()
    {
        yield return new WaitForSeconds(_shootInterval);
        _coolDownRoutine = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, _shootDirection * 100);
    }
}
