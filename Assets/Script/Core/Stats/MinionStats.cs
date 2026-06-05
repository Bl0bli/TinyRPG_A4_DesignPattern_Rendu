using System;
using UnityEngine;

[Serializable]
public class MinionStats : IStats
{
    private IHealth _health;
    public void Init(IHealth health) {
        _health = health;
    }
    
    public IHealth Health => _health;
    [field: SerializeField] public int BaseHealth{ get; private set; }
    [field: SerializeField] public int BaseAttack{ get; private set; }
    [field: SerializeField] public int BaseMagic{ get; private set; }
    [field: SerializeField] public int BaseDefense{ get; private set; }
    [field: SerializeField] public int BaseSpeed { get; private set; }
    public int CurrentAttack { get; set; }
    public int CurrentMagic { get; set; }
    public int CurrentDefense { get; set; }
    public int CurrentSpeed { get; set; }
        
    public void ResetStats() {
        CurrentAttack = BaseAttack;
        CurrentMagic = BaseMagic;
        CurrentDefense = BaseDefense;
        CurrentSpeed = BaseSpeed;
    }
}