using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _animator;
    [SerializeField] private Health _health;

    [Header("Params")] [SerializeField] private float _duration = 1f;
    
    private Coroutine _blendCoroutine;
    private float _walkSpeed = 0f;
    private void Start()
    {
        PlayerController pc = GetComponent<PlayerController>();
        
        if(pc != null) pc.OnMove += SetWalkSpeed;

        if (_health != null)
        {
            _health.OnDie += SetDie;
            _health.OnTakeDamage += SetHit;
        }
    }

    public void OnAttack(AAttack attack) {
        _animator.SetTrigger(attack.Trigger);
    }
    
    private void SetDie()
    {
        _animator.SetTrigger("Die");
    }

    private void SetHit()
    {
        _animator.SetTrigger("Hit");
    }
    private void SetWalkSpeed(float speed)
    {
        if (speed <= 0.0001)
        {
            if(_blendCoroutine != null) StopCoroutine(_blendCoroutine);
            _blendCoroutine = StartCoroutine(Blend(0, 1, _duration, true,(s) =>
            {
                _walkSpeed = s;
                _animator.SetFloat("WalkSpeed", _walkSpeed);
            }));
        }
        else if (_walkSpeed < 1)
        {
            if(_blendCoroutine != null) StopCoroutine(_blendCoroutine);
            _blendCoroutine = StartCoroutine(Blend(_walkSpeed, 1, _duration, false,(s) =>
            {
                _walkSpeed = s;
                _animator.SetFloat("WalkSpeed", _walkSpeed);
            }));
        }
    }

    private IEnumerator Blend(float a, float b,float duration, bool reverse, Action<float> callback)
    {
        float t = 0;
        while (t<duration)
        {
            yield return null;
            float lerp = t / duration;
            if(reverse) lerp = 1 - lerp;
            callback?.Invoke(Mathf.Lerp(a, b, lerp));
            t += Time.deltaTime;
        }
        callback?.Invoke(Mathf.Lerp(a, b, reverse ? 0 : 1));
    }
}
