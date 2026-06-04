using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "UpdateDetection", story: "Check if [Detector] has Target and set [TargetDetected] flag", category: "Action", id: "a68ff9522eae4fe4236611e705d2de83")]
public partial class UpdateDetectionAction : Action
{
    [SerializeReference] public BlackboardVariable<Detector> Detector;
    [SerializeReference] public BlackboardVariable<bool> TargetDetected;

    protected override Status OnUpdate()
    {
        if (Detector.Value != null)
        {
            TargetDetected.Value = Detector.Value.IsTargetInSight();
        }
        return Status.Success;
    }
    
}

