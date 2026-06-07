using System;
using UnityEngine;

public interface IHealth
{
    public int CurrentHealth { get; }
    public void TakeDamage(int damage);
    public void Heal(int amount);
    public void BindOnDie(Action callback);
    public void BindOnTakeDamage(Action callback);

}
