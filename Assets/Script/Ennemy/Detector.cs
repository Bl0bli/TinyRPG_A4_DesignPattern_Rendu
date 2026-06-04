using System;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private Collider _selfCollider;
    
    List<GameObject> _targets = new List<GameObject>();
    
    private void DetectTargets()
    {
        _targets.Clear();
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, _targetLayer);

        foreach (Collider collider in colliders)
        {
            if(collider == _selfCollider || collider.CompareTag("Enemy")) continue;
            
            _targets.Add(collider.gameObject);
        }
    }

    public bool IsTargetInSight()
    {
        return _targets.Count > 0;
    }

    public GameObject GetNearestTarget()
    {
        if (_targets.Count > 0)
        {
            GameObject nearestTarget = _targets[0];
            float nearestDist = Vector3.Distance(nearestTarget.transform.position, transform.position);
            foreach (GameObject target in _targets)
            {
                float currentDist = Vector3.Distance(target.transform.position, transform.position);
                if (nearestDist > currentDist)
                {
                    nearestDist = currentDist;
                    nearestTarget = target;
                }
            }

            return nearestTarget;
        }
        return null;
    }

    private void FixedUpdate()
    {
        DetectTargets();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
