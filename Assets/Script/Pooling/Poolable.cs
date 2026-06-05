using System.Collections;
using UnityEngine;

public abstract class Poolable : MonoBehaviour
{
    [Header("Poolable Params")]
    [Tooltip("Set to -1 for infinite life time"), SerializeField] private float _lifeTime = 3f;
    
    public bool activeSelf => gameObject.activeSelf;
    
    public virtual void Init(Vector3 position, Quaternion rotation, Vector3 direction = default)
    {
        if(_lifeTime > 0) StartCoroutine(LifeTimeRoutine());
    }
    
    protected virtual IEnumerator LifeTimeRoutine()
    {
        yield return new WaitForSeconds(_lifeTime);
        gameObject.SetActive(false);
    }
    
    public virtual void SetActive(bool active) { gameObject.SetActive(active); }
    
}
