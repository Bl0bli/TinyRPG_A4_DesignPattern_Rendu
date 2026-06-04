using UnityEngine;

public interface IHealthStats : IHealth
{
    public int BaseHealth { get; set; }
    public int CurrentHealth { get; set; }
}
