using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "EnnemyDetection", story: "[Detector] has Target", category: "Conditions", id: "c60aa50aad81538e3987457abd1c8d6b")]
public partial class EnnemyDetectionCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Detector> Detector;

    public override bool IsTrue()
    {
        return Detector.Value != null && Detector.Value.IsTargetInSight();
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
