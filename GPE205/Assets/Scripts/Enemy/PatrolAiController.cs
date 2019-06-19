using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAiController : AiController
{
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AiMain();
    }
    public override void Idle()
    {
        ChangeState(AIStates.Patrol);
        base.Idle();
    }
    public override void Patrol(Transform target)
    {
        if(CanSee())
        {
            ChangeAttackState(AIAttackState.Attack);
        }
        if(CanHear())
        {
            ChangeState(AIStates.Chase);
        }
        if(IsBlocked())
        {
            ChangeAvoidState(AIAvoidState.MoveToAvoid);
        }
        base.Patrol(target);
    }
    public override void Attack(Transform target)
    {
        base.Attack(target);
    }
    public override bool MoveToAvoid()
    {
        return base.MoveToAvoid();
    }
    public override void Dead()
    {
        base.Dead();
    }
}
