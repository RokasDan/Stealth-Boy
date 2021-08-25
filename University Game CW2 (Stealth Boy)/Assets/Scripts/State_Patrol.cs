using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class State_Patrol : IState 

{
    // Runner enemy type's attack state from the labs. The only thing i changed is that this script tells the game.
    EnemyController1 owner;

    NavMeshAgent agent;

    Waypoint waypoint;

    public State_Patrol(EnemyController1 owner)
    {
        this.owner = owner;
    }

    public void Enter()
    {
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
            owner.stateMachine.ChangeState(new State_Attack(owner));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Patrol State");
        agent.isStopped = true;
    }
}
