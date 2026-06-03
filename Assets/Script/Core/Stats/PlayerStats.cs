using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Core/PlayerStats")]
public class PlayerStats : ScriptableObject, IStats
{
    [field: SerializeField] public int BaseHealth { get; private set; }
    [field: SerializeField] public int BaseAttack{ get; private set; }
    [field: SerializeField] public int BaseMagic{ get; private set; }
    [field: SerializeField] public int BaseDefense{ get; private set; }
    [field: SerializeField] public int BaseSpeed { get; private set; }
    
    public int CurrentHealth
    {
        get => _healthStats.CurrentHealth; 
        set => _healthStats.CurrentHealth = value;
    }
    public IHealth Health => _healthStats;
    
    public int CurrentAttack{ get; set; }
    public int CurrentMagic{ get; set; }
    public int CurrentDefense{ get; set; }
    public int CurrentSpeed { get; set; }
    
    private IHealthStats _healthStats;

    public void Init(IHealthStats playerHealth) {
        _healthStats = playerHealth;
        _healthStats.BaseHealth = BaseHealth;
        _healthStats.CurrentHealth = BaseHealth;
        CurrentAttack = BaseAttack;
        CurrentDefense = BaseDefense;
        CurrentMagic = BaseMagic;
        CurrentSpeed = BaseSpeed;
    }
}
