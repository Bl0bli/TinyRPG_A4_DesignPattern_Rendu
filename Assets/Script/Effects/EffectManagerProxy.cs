using UnityEngine;

public class EffectManagerProxy : MonoBehaviour, IEffectManager
{
    [SerializeField] private Character _character;
    
    public void AddEffect(IEffect effect) {
        _character.AddEffect(effect);
    }
    public void RemoveEffect(IEffect effect) {
        _character.RemoveEffect(effect);
    }
}
