using UnityEngine;

public class PoisonAttack : AAttack
{
    [SerializeField] private int _initialDamage;
    [SerializeField] private int _damagePerTicks;
    [SerializeField] private int _numberOfTicks;
    [SerializeField] private float _slowPower;
    [SerializeField] private float _slowDuration;
    
    protected override void Hit(IHealth health) {
        if (SourceStats != null) health.TakeDamage(_initialDamage + SourceStats.CurrentAttack);
        else health.TakeDamage(_initialDamage);
    }

    protected override void AddEffect(IEffectManager em) {
        em.AddEffect(new Both(
            new Poison(_damagePerTicks, _numberOfTicks), 
            new Slow(_slowPower, _slowDuration)
            ));
    }
}
