using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private string _objectPoolingName;
    [SerializeField] private Poolable _objectPrefab;
    [SerializeField] private int _poolSize = 10;
    
    private List<Poolable> _pooledObjects = new List<Poolable>();
    private Coroutine _poolSizeDecreaseRoutine;
    
    private void OnEnable()
    {
        PoolingServiceLocator.Register(_objectPoolingName, this);

    }

    private void OnDisable()
    {
        PoolingServiceLocator.Unregister(_objectPoolingName);

    }

    private void Start()
    {
        Poolable tmp;

        for (int i = 0; i < _poolSize; i++)
        {
            tmp = Instantiate(_objectPrefab, transform);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }
    }
    
    public Poolable GetPoolable()
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeSelf)
            {
                _pooledObjects[i].Disable();
                _pooledObjects[i].SetActive(true);
                return _pooledObjects[i];
            }
        }

        Poolable tmp = Instantiate(_objectPrefab, transform);
        tmp.Disable();
        tmp.SetActive(true);
        _pooledObjects.Add(tmp);
        if(_poolSizeDecreaseRoutine != null) StopCoroutine(_poolSizeDecreaseRoutine);
        _poolSizeDecreaseRoutine = StartCoroutine(PoolSizeDecrease());
        return tmp;
    }

    private IEnumerator PoolSizeDecrease()
    {
        yield return new WaitForSeconds(3f);
        while (_pooledObjects.Count > _poolSize)
        {
            Poolable tmp = _pooledObjects[_pooledObjects.Count - 1];
            _pooledObjects.RemoveAt(_pooledObjects.Count - 1);
            Destroy(tmp.gameObject);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
