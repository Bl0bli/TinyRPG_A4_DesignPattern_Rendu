using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public abstract class AAttack : MonoBehaviour
{
    [SerializeField, Tag] private string _targetTag;
    [SerializeField] private float _lastingDuration;
    [SerializeField] private string _animationTrigger;

    private HashSet<IHealth> _alreadyHit = new HashSet<IHealth>();

    public IReadOnlyStats SourceStats { get; set; }

    public string Trigger => _animationTrigger;

    private void Start() {
        Destroy(gameObject, _lastingDuration);
        Begin();
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(_targetTag)) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health != null) {
            if (_alreadyHit.Contains(health)) return;
            Hit(health);
            _alreadyHit.Add(health);
        }
        IEffectManager em = other.GetComponent<IEffectManager>();
        if(em != null) AddEffect(em);
    }

    protected virtual void Hit(IHealth health) {}
    
    protected virtual void Begin(){}
    
    protected virtual void AddEffect(IEffectManager em){}
}
