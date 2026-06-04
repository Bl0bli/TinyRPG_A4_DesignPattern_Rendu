using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "Try [Attacking] [Detector] Target", category: "Action", id: "02fe36fb9abb763fff16c97a189ab2aa")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<EnnemyAttack> Attacking;
    [SerializeReference] public BlackboardVariable<Detector> Detector;
    [SerializeReference] public BlackboardVariable<float> Dist;

    protected override Status OnStart()
    {
        GameObject nearestTarget = Detector.Value.GetNearestTarget();
        if (nearestTarget == null || Vector3.Distance(Detector.Value.transform.position, nearestTarget.transform.position) > Dist.Value) 
        {
            return Status.Failure; 
        }
        Attacking.Value.Attack();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        GameObject nearestTarget = Detector.Value.GetNearestTarget();
        
        if (nearestTarget == null || Vector3.Distance(Detector.Value.transform.position, nearestTarget.transform.position) > Dist.Value) 
        {
            return Status.Failure; 
        }
        
        Attacking.Value.Attack();
        return Status.Running;
    }
}

