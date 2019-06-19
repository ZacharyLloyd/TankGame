﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAiController : AiController
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
        if(CanHear())
        {
            ChangeState(AIStates.Chase);
        }
        if(CanSee())
        {
            ChangeAttackState(AIAttackState.Attack);
        }
        if(IsBlocked())
        {
            ChangeAvoidState(AIAvoidState.MoveToAvoid);
        }
        base.Patrol(target);
    }
    public override void Attack(Transform target)
    {
        if(pawn.health < 50f / pawn.maxHealth)
        {
            ChangeState(AIStates.Flee);
        }
        base.Attack(target);
    }
    public override void Flee(Transform target)
    {
        base.Flee(target);
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
