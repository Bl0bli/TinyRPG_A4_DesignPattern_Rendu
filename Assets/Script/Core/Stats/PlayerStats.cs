using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Core/PlayerStats")]
public class PlayerStats : ScriptableObject, IStats, IReadOnlyStats
{
    [field: SerializeField] public int BaseHealth{ get; private set; }
    [field: SerializeField] public int BaseAttack{ get; private set; }
    [field: SerializeField] public int BaseMagic{ get; private set; }
    [field: SerializeField] public int BaseDefense{ get; private set; }
    [field: SerializeField] public int BaseSpeed { get; private set; }


    public int CurrentAttack{ get; set; }
    public int CurrentMagic{ get; set; }
    public int CurrentDefense{ get; set; }
    public int CurrentSpeed { get; set; }

    public IHealth Health { get; private set; }

    public int CurrentHealth => Health.CurrentHealth;
    

    public void Init(IHealth health) {
        Health = health;
        CurrentAttack = BaseAttack;
        CurrentDefense = BaseDefense;
        CurrentMagic = BaseMagic;
        CurrentSpeed = BaseSpeed;
    }
    
    public void ResetStats() {
        CurrentAttack = BaseAttack;
        CurrentDefense = BaseDefense;
        CurrentMagic = BaseMagic;
        CurrentSpeed = BaseSpeed;
    }
}
