using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAiController : AiController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AiMain();
    }
    public override void Idle()
    {
        if (CanHear())
        {
            ChangeState(AIStates.Chase);
        }
        if (CanSee())
        {
            ChangeAttackState(AIAttackState.Attack);
        }
    }
    public override void Chase(Transform target)
    {
        base.Chase(target);
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
