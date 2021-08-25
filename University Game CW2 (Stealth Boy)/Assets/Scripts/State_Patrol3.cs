using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Patrol3 : IState
{
    // Patrol state for the Boss enemy type. This is the same patrol state as the one we did within the labs.
    // todo: private GameController gameController;
    EnemyController3 owner;

    NavMeshAgent agent;

    Waypoint waypoint;

    public State_Patrol3(EnemyController3 owner)
    {
        this.owner = owner;
    }

    public void Enter()
    {
        // todo: gameController.IncrementSpotted();
        
        Debug.Log("Entering Patrol State");

        waypoint = owner.waypoint;
        agent = owner.GetComponent<NavMeshAgent>();
        agent.destination = waypoint.transform.position;
        agent.isStopped = false;
    }

    public void Execute()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Waypoint nextWaypoint = waypoint.NextWaypoint;
            waypoint = nextWaypoint;
            agent.destination = waypoint.transform.position;
        }

        // Transitioning to attack if seen
        if (owner.IsTarget)
        {
            owner.stateMachine.ChangeState(new State_Attack3(owner));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Patrol State");
        agent.isStopped = true;
    }
}
