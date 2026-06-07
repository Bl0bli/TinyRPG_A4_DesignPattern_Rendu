using System;
using Unity.Behavior;
using UnityEngine;

public class Minion : Character
{
    [SerializeField] private MinionStats _stats = new MinionStats();
    [SerializeField] private BehaviorGraphAgent _agent;
    private Health _health;

    private void Start()
    {
        BindOnTakeDamage(() => _anmController.SetHit());
        BindOnDie(() =>
        {
            _anmController.SetDie();
            _agent.enabled = false;
            _hitbox.SetActive(false);
        });
    }

    protected override IStats GetSourceStats() {
        _stats.Init(_health);
        return _stats;
    }
    
    protected override IHealth GetSourceHealth() {
        Health health = new Health(_stats.BaseHealth);
        return health;
    }
}

