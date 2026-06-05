using UnityEngine;

public class HealthProxy : MonoBehaviour, IHealth
{
    [Header("References")]
    [SerializeField] private Character _health;


    public int CurrentHealth => _health.CurrentHealth;
    
    public void TakeDamage(int damage)
    {
        if (_health == null)
        {
            Debug.LogError($"Health component not found, can't take damage");
            return;
        }
        _health.TakeDamage(damage);
    }

    public void Heal(int amount)
    {
        if (_health == null)
        {
            Debug.LogError($"Health component not found, can't heal");
            return;
        }
        _health.Heal(amount);
    }
}
