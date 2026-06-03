using System;
using NaughtyAttributes;
using UnityEngine;

public abstract class AAttack : MonoBehaviour
{
    [SerializeField, Tag] private string _targetTag;
    [SerializeField] private float _lastingDuration;
    [SerializeField] private string _animationTrigger;

    public string Trigger => _animationTrigger;

    private void Start() {
        Destroy(gameObject, _lastingDuration);
        Begin();
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(_targetTag)) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;
        Hit(health);

    }

    protected virtual void Hit(IHealth health) {}
    
    protected virtual void Begin(){}
}
