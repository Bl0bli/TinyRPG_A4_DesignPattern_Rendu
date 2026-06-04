using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnnemyAttack : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AAttack _playerAttack;
    
    [Header("Params")]
    [SerializeField] private float _cooldown;
    
    [Header("Events")]
    [SerializeField] private UnityEvent<AAttack> _onAttack;
    
    private bool _canAttack = true;
    
    public void Attack()
    {
        if (!_canAttack) return;
        StartCoroutine(CooldownRoutine());
        
        AAttack attack = Instantiate(_playerAttack, transform, false);
        attack.SourceStats = Resources.Load<PlayerStats>("PlayerStats"); //TODO le faire au start
        _onAttack?.Invoke(attack);
    }
    
    private IEnumerator CooldownRoutine() {
        float t = 0;
        _canAttack = false;
        while (t < _cooldown) {
            yield return null;
            t += Time.deltaTime;
        }
        _canAttack = true;
    }
}
