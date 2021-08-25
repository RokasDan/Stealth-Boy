using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Search2 : IState
{
    // Search state for the gunner enemy types. This state is the same as the one we did within the AI labs.
    EnemyController2 owner;
    NavMeshAgent agent;
    private float Searchtime;
    
    public State_Search2(EnemyController2 owner)
    {
        this.owner = owner;
    }
    
    
    public void Enter()
    {
        owner.GreenLightOn();
        Debug.Log("Entering Search State");
        agent = owner.GetComponent<NavMeshAgent>();

        
        agent.destination = owner.lastSeenPosition;
        agent.isStopped = false;

        Searchtime = Time.time;

    }

    public void Execute()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.isStopped = false;
        }

        if (Time.time > Searchtime + owner.SearchTime)
        {
            owner.stateMachine.ChangeState(new State_Patrol2(owner));
        }
        
        if (owner.IsTarget == true)
        {
            Debug.Log("Player Seen Again");
            owner.stateMachine.ChangeState(new State_Attack2(owner));
        }
    }

    public void Exit()
    {
        owner.GreenLightOff();
        Debug.Log("Exit Search State");
    }
}
