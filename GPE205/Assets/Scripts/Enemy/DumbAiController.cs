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
        if (CanHear(target.transform))
        {
            ChangeState(AIStates.Chase);
        }
        base.Idle();
    }
    public override void Chase(Transform target)
    {
        if (CanSee())
        {
            ChangeAttackState(AIAttackState.Attack);
        }
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
