using System;
using UnityEngine;

public class Health : IHealth
{
    private readonly int _maxHealth;
    
    private int _currentHealth;
    private bool _isDead;
    
    public Health(int maxHealth) {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    public event Action OnDie;
    public event Action OnTakeDamage;

    public bool IsDead => _isDead;

    public int CurrentHealth { 
        get => _currentHealth; 
        set => _currentHealth = value;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError($"[HEALTH] - TakeDamage() - Euh frero tu fais de la merde, tema la valeur de damage {damage} elle est négative");
            return;
        }

        if (_currentHealth <= 0) return;
        _currentHealth -= damage;
        Debug.Log($"Took Damages : {CurrentHealth}");
        OnTakeDamage?.Invoke();
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError($"[HEALTH] - Heal() - Euh frero tu fais de la merde, tema la valeur de amount {amount} elle est négative");
            return;
        }

        if (_isDead) return;
        _currentHealth += amount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }

    private void Die()
    {
        _isDead = true;
        OnDie?.Invoke();
    }
    
}
