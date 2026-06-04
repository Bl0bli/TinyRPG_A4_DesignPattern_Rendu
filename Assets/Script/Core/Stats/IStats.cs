using UnityEngine;

public interface IStats
{
    public int BaseHealth { get; }
    public int BaseAttack{ get; }
    public int BaseMagic{ get; }
    public int BaseDefense{ get; }
    public int BaseSpeed { get; }
    
    public int CurrentHealth { get; set; }
    public int CurrentAttack{ get; set; }
    public int CurrentMagic{ get; set;}
    public int CurrentDefense{ get; set; }
    public int CurrentSpeed { get; set; }
}
