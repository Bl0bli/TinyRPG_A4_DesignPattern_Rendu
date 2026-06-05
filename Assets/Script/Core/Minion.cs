using System;
using UnityEngine;

public class Minion : Character
{
    [SerializeField] private MinionStats _stats = new MinionStats();
    private Health _health;
    
    protected override IStats GetSourceStats() {
        _stats.Init(_health);
        return _stats;
    }
    
    protected override IHealth GetSourceHealth() {
        Health health = new Health(_stats.BaseHealth);
        return health;
    }
}

