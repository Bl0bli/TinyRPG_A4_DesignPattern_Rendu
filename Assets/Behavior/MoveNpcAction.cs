using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveNPC", story: "Move [NPC] to [Dectetor] target", category: "Action", id: "3427e36e93519348db46335d8d7c0465")]
public partial class MoveNpcAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> NPC;
    [SerializeReference] public BlackboardVariable<Detector> Dectetor;
    [SerializeReference] public BlackboardVariable<string> AnimatorSpeedParam = new BlackboardVariable<string>("WalkSpeed");
    
    private NavMeshAgent _agent;
    private Animator _animator;

    protected override Status OnStart()
    {
        if (NPC.Value != null)
        {
            _agent = NPC.Value.GetComponent<NavMeshAgent>();
            _animator = NPC.Value.GetComponentInChildren<Animator>();
        }

        if (_agent == null) return Status.Failure;

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Dectetor.Value == null) return Status.Failure;
        
        GameObject target = Dectetor.Value.GetNearestTarget();
        if (target == null) return Status.Failure;
        
        _agent.SetDestination(target.transform.position);
        if (_animator != null)
        {
            _animator.SetFloat(AnimatorSpeedParam.Value, _agent.velocity.magnitude);
        }
        
        return Status.Running;
    }

    protected override void OnEnd()
    {
        if (_agent != null && _agent.isOnNavMesh)
        {
            _agent.ResetPath();
        }
        if (_animator != null)
        {
            _animator.SetFloat(AnimatorSpeedParam.Value, 0f);
        }
    }

}

