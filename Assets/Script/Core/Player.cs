using UnityEngine;

public class Player : Character
{
    [SerializeField] private PlayerStats _stats;
    private Health _health;
    
    protected override IStats GetSourceStats() {
        _stats.Init(_health);
        return _stats;
    }
    
    protected override IHealth GetSourceHealth() {
        _health = new Health(_stats.BaseHealth);
        return _health;
    }
}
