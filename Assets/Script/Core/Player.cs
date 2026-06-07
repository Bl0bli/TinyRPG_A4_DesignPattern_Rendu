using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private PlayerStats _stats;
    [SerializeField] private PlayerController _playerController;
    private Health _health;

    private void Start()
    {
        BindOnTakeDamage(() => _anmController.SetHit());
        BindOnDie(() =>
        {
            _anmController.SetDie();
            _playerController.enabled = false;
            _hitbox.SetActive(false);
        });
    }

    protected override IStats GetSourceStats() {
        _stats.Init(_health);
        return _stats;
    }
    
    protected override IHealth GetSourceHealth() {
        _health = new Health(_stats.BaseHealth);
        return _health;
    }
}
