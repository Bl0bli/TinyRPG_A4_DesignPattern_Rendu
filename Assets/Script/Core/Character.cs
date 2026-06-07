using System;
using UnityEngine;

public abstract class Character : MonoBehaviour, IHealth, IStats, IReadOnlyStats, IEffectManager
{
    [SerializeField] protected GameObject _hitbox;
    [SerializeField] protected AnimationController _anmController;
    
    private IHealth _health;
    private IStats _stats;
    private EffectManager _effectManager;

    private void Awake() {
        _health = GetSourceHealth();
        _stats = GetSourceStats();
        _effectManager = gameObject.AddComponent<EffectManager>();
        _effectManager.Init(_stats);
    }
    
    protected abstract IStats GetSourceStats();
    protected abstract IHealth GetSourceHealth();

    public int CurrentHealth => _health.CurrentHealth;
    public void TakeDamage(int damage) {
        _health.TakeDamage(damage);
    }
    public void Heal(int amount) {
        _health.Heal(amount);
    }

    public void BindOnDie(Action callback)
    {
        _health.BindOnDie(callback);
    }

    public void BindOnTakeDamage(Action callback)
    {
        _health.BindOnTakeDamage(callback);
    }

    public IHealth Health => _health;
    public int BaseAttack => _stats.BaseAttack;
    public int BaseMagic => _stats.BaseMagic;
    public int BaseDefense => _stats.BaseDefense;
    public int BaseSpeed => _stats.BaseSpeed;

    public int CurrentAttack
    {
        get => _stats.CurrentAttack;
        set => _stats.CurrentAttack = value;
    }
    public int CurrentMagic {
        get => _stats.CurrentMagic;
        set => _stats.CurrentMagic = value;
    }
    public int CurrentDefense {
        get => _stats.CurrentDefense;
        set => _stats.CurrentDefense = value;
    }
    public int CurrentSpeed{
        get => _stats.CurrentSpeed;
        set => _stats.CurrentSpeed = value;
    }
    
    public void ResetStats() {
        _stats.ResetStats();
    }
    public void AddEffect(IEffect effect) {
        _effectManager.AddEffect(effect);
    }
    public void RemoveEffect(IEffect effect) {
        _effectManager.RemoveEffect(effect);
    }
}
