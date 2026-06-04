using UnityEngine;

public interface IEffect
{
    public int Priority { get; }
    public bool ShouldDestroy { get; }
    
    public void Apply(IStats stats);
}
