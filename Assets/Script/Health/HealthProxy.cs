using System;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthProxy : MonoBehaviour, IHealth
{
    [FormerlySerializedAs("_health")]
    [Header("References")]
    [SerializeField] private Character _character;


    public int CurrentHealth => _character.CurrentHealth;
    
    public void TakeDamage(int damage)
    {
        if (_character == null)
        {
            Debug.LogError($"Health component not found, can't take damage");
            return;
        }
        _character.TakeDamage(damage);
    }

    public void Heal(int amount)
    {
        if (_character == null)
        {
            Debug.LogError($"Health component not found, can't heal");
            return;
        }
        _character.Heal(amount);
    }

    public void BindOnDie(Action callback)
    {
        _character.BindOnDie(callback);
    }

    public void BindOnTakeDamage(Action callback)
    {
        _character.BindOnTakeDamage(callback);
    }
}
