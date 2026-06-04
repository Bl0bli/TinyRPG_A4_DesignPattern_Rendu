using UnityEngine;

public interface IReadOnlyStats
{
    public int CurrentHealth { get; }
    public int CurrentAttack{ get; }
    public int CurrentMagic{ get; }
    public int CurrentDefense{ get; }
    public int CurrentSpeed { get; }
}
