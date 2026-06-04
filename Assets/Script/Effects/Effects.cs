using UnityEngine;

public class Both : IEffect
{
    private readonly IEffect _a;
    private readonly IEffect _b;

    public Both(IEffect a, IEffect b) {
        _a = a;
        _b = b;
    }

    public int Priority => Mathf.Max(_a.Priority, _b.Priority);
    public bool ShouldDestroy => _a.ShouldDestroy && _b.ShouldDestroy;
    
    public void Apply(IStats stats) {
        _a.Apply(stats);
        _b.Apply(stats);
    }
}

public class Damage : IEffect
{
    private readonly int _damage;
    
    public Damage(int damage) {
        _damage = damage;
    }

    public int Priority => 0;
    public bool ShouldDestroy { get; private set; }
    
    public void Apply(IStats stats) {
        stats.Health.TakeDamage(_damage);
        ShouldDestroy = true;
    }
}

public class Poison : IEffect
{
    private readonly int _damagePerTick;
    private readonly int _numberOfTicks; //TODO Mettre un Poison tick delay
    
    public Poison(int damagePerTick, int numberOfTicks) {
        _damagePerTick = damagePerTick;
        _numberOfTicks = numberOfTicks;
    }

    public int Priority => 0;
    public bool ShouldDestroy { get; private set; }

    private int _tickCounter;
    public void Apply(IStats stats) {
        stats.Health.TakeDamage(_damagePerTick);
        _tickCounter++;
        if (_tickCounter > _numberOfTicks) {
            ShouldDestroy = true;
        }
    }
}

public class Slow : IEffect
{
    private readonly float _power;
    private readonly float _duration;
    
    public Slow(float power, float duration) {
        _power = Mathf.Clamp(_power, 0, 1);
        _duration = duration;
    }

    public int Priority => 1;
    public bool ShouldDestroy { get; private set; }

    private float _accumulator = 0f;
    
    public void Apply(IStats stats) {
        _accumulator += EffectManager.TickDelay;
        stats.CurrentSpeed = Mathf.FloorToInt(_power * stats.CurrentSpeed);
        if (_accumulator > _duration) ShouldDestroy = true;
    }
}