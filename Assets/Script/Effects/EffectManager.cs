using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IEffectManager
{
    public void AddEffect(IEffect effect);
    public void RemoveEffect(IEffect effect);
}

public class EffectManager : MonoBehaviour, IEffectManager
{
    public const float TickDelay = 0.1f;
    private IStats _managedStatSheet;

    private List<IEffect> _effects = new List<IEffect>();

    private float accumulator = 0.0f;
    
    public void Init(IStats managedStatSheet) {
        _managedStatSheet = managedStatSheet;
    }

    private void Update() {
        accumulator += Time.deltaTime;

        while (accumulator > TickDelay) {
            accumulator -= TickDelay;
            _managedStatSheet.ResetStats();
            foreach (IEffect effect in _effects.Where(effect => !effect.ShouldDestroy)) {
                effect.Apply(_managedStatSheet);
            }
            Cleanse();
        }
    }

    public void AddEffect(IEffect effect) {
        _effects.Add(effect);
        _effects = _effects.OrderBy(e => e.Priority).ToList();
    }

    public void RemoveEffect(IEffect effect) {
        _effects.Remove(effect);
    }

    private void Cleanse() {
        for (int i = _effects.Count - 1; i >= 0; i--) {
            if (_effects[i].ShouldDestroy) {
                _effects.RemoveAt(i);
            }
        }
    }
}
