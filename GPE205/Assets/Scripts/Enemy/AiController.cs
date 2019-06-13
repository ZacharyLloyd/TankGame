using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    //Creating a reference for timer to use its properties and methods
    public Timer timer;
    public TankData pawn;
    //The properties used in this script
    public Transform enemyPointOfFire;
    public GameObject enemyBulletPrefab;
    //Parts for the AI
    public LoopTypes loopType;
    public List<Transform> waypoints;
    public int currentWaypoint;
    public float cutoff;
    public bool isForward;
    public float stateStartTime;
    public AIStates currentState;
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
        Flee
    };

    public enum AIAvoidState
    {
        None,
        TurnToAvoid,
        MoveToAvoid
    };
    // Update is called once per frame
    void Update()
    {
        //enemyBulletPrefab.transform.position = enemyPointOfFire.position;
        //enemyBulletPrefab.transform.rotation = enemyPointOfFire.rotation;
        //if (GameManager.instance.currentEnemyHealth <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }
    //public void EnemyShoot(GameObject enemyBulletPrefab)
    //{
    //        Instantiate(enemyBulletPrefab);
    //}
    //public void InitiateEnemyControls(float seconds)
    //{
    //    timer.StartTimer();
    //    if (timer.currentTime > seconds)
    //    {
    //        EnemyShoot(enemyBulletPrefab.gameObject);
    //        timer.ResetTime();
    //    }
    //}
    public void ChangeState(AIStates newState)
    {
        //Saving the time of entering a new state
        stateStartTime = Time.time;
        currentState = newState;
        //Reset the avoidance state
        currentAvoidState = AIAvoidState.None;
    }
    public void ChangeAvoidState(AIAvoidState newState)
    {
        startAvoidTime = Time.time;
        currentAvoidState = newState;
    }
    public void Idle()
    {
        //Does nothing
    }
    public bool isBlocked()
    {
        if(Physics.Raycast(pawn.bodytf.position, pawn.bodytf.forward, feelerDistance))
        {
            return true;
        }
        return false;
    }
    public void Seek(Transform target)
    {
        switch(currentAvoidState)
        {
            case AIAvoidState.None:
                //Chase
                Vector3 targetVector = (target.position - pawn.bodytf.position).normalized;
                pawn.mover.RotateTowards(targetVector);
                pawn.mover.Move(Vector3.forward);
                //If blocked
                if(isBlocked())
                {
                    //Change to TurnToAvoid
                    ChangeAvoidState(AIAvoidState.TurnToAvoid);
                }
                break;
            case AIAvoidState.TurnToAvoid:
                //Rotate
                pawn.mover.Rotate(1);
                //If not blocked
                if(!isBlocked())
                {
                    ChangeAvoidState(AIAvoidState.MoveToAvoid);
                }
                break;
            case AIAvoidState.MoveToAvoid:
                //Move forward
                pawn.mover.Move(Vector3.forward);
                //If blocked
                if(isBlocked())
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
    public void SeekPoint(Vector3 targetPoint)
    {
        Vector3 targetVector = (targetPoint - pawn.bodytf.position).normalized;
        pawn.mover.RotateTowards(targetVector);
        pawn.mover.Move(Vector3.forward);
    }
    public void Flee(Transform target)
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
    public void Patrol()
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
}
