using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [Header("Params")] 
    [SerializeField] private int _maxHealth = 10;
    
    private int _currentHealth;
    private bool _isDead;
    
    public bool IsDead => _isDead;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
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
    }
    
}
