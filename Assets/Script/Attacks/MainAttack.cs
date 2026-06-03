using UnityEngine;

public class MainAttack : AAttack
{
    [SerializeField] private int _damages;
    
    protected override void Hit(IHealth health) {
        health.TakeDamage(_damages);
    }
}
