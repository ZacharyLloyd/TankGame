using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    //Creating a reference for timer to use its properties and methods
    public Timer timer;
    public TankData pawn;
    public Shoot shoot;
    public Noisemaker noisemaker;
    //The properties used in this script
    public Transform enemyPointOfFire;
    public GameObject enemyBulletPrefab;
    //Parts for the AI
    public TankData target;
    public LoopTypes loopType;
    public List<Transform> waypoints;
    public int currentWaypoint;
    public float cutoff;
    public bool isForward;
    public float startStateTime;
    public AIStates currentState;
    public float startAttackTime;
    public AIAttackState currentAttackState = AIAttackState.None;
    public bool isDead = false;
    public float hearingScale;
    //Object Avoidance
    public AIAvoidState currentAvoidState = AIAvoidState.None;
    public float feelerDistance;
    public float avoidMoveTime;
    public float startAvoidTime;


    public enum LoopTypes
    {
        Loop,
        Stop,
        PingPong,
        Random
    };

    public enum AIStates
    {
        Idle,
        Patrol,
        Chase,
        Flee,
        Dead
    };

    public enum AIAvoidState
    {
        None,
        TurnToAvoid,
        MoveToAvoid
    };
    public enum AIAttackState
    {
        None,
        Attack
    }
    private void Start()
    {
        shoot = GetComponent<Shoot>();
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = FindObjectOfType<ImmaPlayer>().gameObject.GetComponent<TankData>();
        }
        if(!isDead)
        {
            AiMain();
        }
        if(pawn.health <= 0)
        {
            ChangeState(AIStates.Dead);
        }
    }
    protected void AiMain()
    {
        if (target != null)
        {
            switch (currentState)
            {
                case AIStates.Idle:
                    Idle();
                    break;
                case AIStates.Patrol:
                    Patrol(target.transform);
                    break;
                case AIStates.Chase:
                    Chase(target.transform);
                    break;
                case AIStates.Flee:
                    Flee(target.transform);
                    break;
                case AIStates.Dead:
                    Dead();
                    break;
                default:
                    break; 
            }
        }
        switch (currentAvoidState)
        {
            case AIAvoidState.None:
                break;
            case AIAvoidState.MoveToAvoid:
                MoveToAvoid();
                break;
            default:
                break;
        }
        switch (currentAttackState)
        {
            case AIAttackState.None:
                break;
            case AIAttackState.Attack:
                if (target)
                {
                    Attack(target.transform); 
                }
                break;
            default:
                break;
        }
    }
    public void ChangeState(AIStates newState)
    {
        timer.StartTimer(0);
        startStateTime = timer.currentTime[0];
        currentState = newState;
        currentAvoidState = AIAvoidState.None;
    }
    public void ChangeAvoidState(AIAvoidState newState)
    {
        timer.StartTimer(1);
        startAvoidTime = timer.currentTime[1];
        currentAvoidState = newState;
    }
    public void ChangeAttackState(AIAttackState newState)
    {
        timer.StartTimer(3);
        startAttackTime = timer.currentTime[3];
        currentAttackState = newState;
    }
    public virtual bool IsBlocked()
    {
        if(Physics.Raycast(pawn.bodytf.position, pawn.bodytf.forward, out RaycastHit hit, feelerDistance))
        {
            if(hit.collider.tag == "Rock")
            return true;
        }
        return false;
    }
    public virtual void Seek(Transform target)
    {
        switch(currentAvoidState)
        {
            case AIAvoidState.None:
                //Chase
                Vector3 targetVector = (target.position - pawn.bodytf.position).normalized;
                pawn.mover.RotateTowards(targetVector);
                pawn.mover.Move(Vector3.forward);
                //If blocked
                if(IsBlocked())
                {
                    //Change to TurnToAvoid
                    ChangeAvoidState(AIAvoidState.TurnToAvoid);
                }
                break;
            case AIAvoidState.TurnToAvoid:
                //Rotate
                pawn.mover.Rotate(1);
                //If not blocked
                if(!IsBlocked())
                {
                    ChangeAvoidState(AIAvoidState.MoveToAvoid);
                }
                break;
            case AIAvoidState.MoveToAvoid:
                //Move forward
                pawn.mover.Move(Vector3.forward);
                //If blocked
                if(IsBlocked())
                {
                    ChangeAvoidState(AIAvoidState.TurnToAvoid);
                }
                //If time avoiding is up
                if(Time.time > startAvoidTime + avoidMoveTime)
                {
                    ChangeAvoidState(AIAvoidState.None);
                }
                break;
        }
    }
    public virtual void SeekPoint(Vector3 targetPoint)
    {
        Vector3 targetVector = (targetPoint - pawn.bodytf.position).normalized;
        pawn.mover.RotateTowards(targetVector);
        pawn.mover.Move(Vector3.forward);
    }
    public virtual bool MoveToAvoid()
    {
        RaycastHit hit;
        if(Physics.Raycast(pawn.transform.position, transform.forward, out hit, feelerDistance))
        {
            if(hit.collider.tag == "Rock")
            {
                pawn.mover.Rotate(pawn.rotateSpeed * Time.deltaTime);
                return true;
            }
            else
            {
                ChangeState(AIStates.Patrol);
                ChangeAvoidState(AIAvoidState.None);
                return false;
            }
        }
        return false;
    }
    public virtual void Idle()
    {
        //Does nothing
    }
    public virtual void Flee(Transform target)
    {
        //Find the vector to the target
        Vector3 targetVector = (target.position - pawn.bodytf.position);
        //Find inverse/opposite of that vector
        Vector3 awayVector = -targetVector;
        //Rotate towards it
        pawn.mover.RotateTowards(awayVector);
        //Move forwards(away from player)
        pawn.mover.Move(Vector3.forward);
    }
    public virtual void Patrol(Transform target)
    {
        //Seek the targeted waypoint
        Seek(waypoints[currentWaypoint]);

        //If the enemy is close enough
        if(Vector3.Distance(pawn.bodytf.position, waypoints[currentWaypoint].position) <= cutoff)
        {
            //Advance to the next waypoint
            if(isForward)
            {
                currentWaypoint++;
            }
            else
            {
                currentWaypoint--;
            }
            //If the enemy is out of bounds on their waypoints
            if(currentWaypoint >= waypoints.Count || currentWaypoint < 0)
            {
                //Adjust based on loop type
                if(loopType == LoopTypes.Loop)
                {
                    currentWaypoint = 0;
                }
                else if(loopType == LoopTypes.Random)
                {
                    currentWaypoint = Random.Range(0, waypoints.Count);
                }
                else if (loopType == LoopTypes.PingPong)
                {
                    isForward = !isForward;
                    if(currentWaypoint >= waypoints.Count)
                    {
                        currentWaypoint = waypoints.Count - 1;
                    }
                    else
                    {
                        currentWaypoint = 0;
                    }
                }
            }
        }
    }
    public virtual void Chase(Transform target)
    {
        Vector3 targetVector = (target.position - pawn.bodytf.position).normalized;
        pawn.mover.RotateTowards(targetVector);
        pawn.mover.Move(Vector3.forward);
    }
    public virtual void Attack(Transform target)
    {
        shoot.InitateEnemyShoot(pawn.shotsPerSecond);
    }
    public virtual void Dead()
    {
        isDead = true;
    }
    public bool CanHear(Transform target)
    {
        //If the target does not have a noisemaker we cannot hear them
        noisemaker = target.GetComponent<Noisemaker>();
        if (noisemaker == null)
        {
            return false;
        }
        //If they do have a noisemaker, check distance -- if it is <= (PlayerVolume * hearingScale), then we can hear them
        if (Vector3.Distance(target.position, transform.position) <= noisemaker.PlayerVolume * hearingScale)
        {
            return true;
        }
        //Otherwise enemies cannot hear player
        return false;
    }
    public bool CanSee()
    {
        RaycastHit hit;
        Debug.DrawRay(enemyPointOfFire.position, transform.forward * feelerDistance, Color.red);
        if(Physics.Raycast(enemyPointOfFire.position, pawn.transform.forward, out hit, feelerDistance))
        {
            if(hit.collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }
}