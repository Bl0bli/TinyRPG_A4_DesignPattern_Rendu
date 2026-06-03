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
        if (damage < 0)
        {
            Debug.LogError($"[HEALTH] - TakeDamage() - Euh frero tu fais de la merde, tema la valeur de damage {damage} elle est négative");
            return;
        }
        _currentHealth -= damage;
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
    }
    
}
