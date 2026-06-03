using UnityEngine;

public class MainAttack : AAttack
{
    [SerializeField] private int _damages;
    
    protected override void Hit(IHealth health) {
        if (SourceStats != null) health.TakeDamage(_damages + SourceStats.CurrentAttack); //TODO Faire une jolie formule de damages en vré
        else health.TakeDamage(_damages);
    }
}
