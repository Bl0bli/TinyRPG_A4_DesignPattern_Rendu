using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
     [Header("References")]
     [SerializeField] private InputActionReference _attack;
     [SerializeField] private AAttack _playerAttack;

     [Header("Params")]
     [SerializeField] private float _cooldown;

     [Header("Events")]
     [SerializeField] private UnityEvent<AAttack> _onAttack;

     private bool _canAttack = true;

     private void OnEnable() {
          _attack.action.started += RequestAttack;
          _attack.action.Enable();
     }

     private void OnDisable() {
          _attack.action.started -= RequestAttack;
          _attack.action.Disable();
     }

     private void RequestAttack(InputAction.CallbackContext obj) {
          if (!_canAttack) return;
          Attack();
          StartCoroutine(CooldownRoutine());
     }

     private void Attack() {
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
