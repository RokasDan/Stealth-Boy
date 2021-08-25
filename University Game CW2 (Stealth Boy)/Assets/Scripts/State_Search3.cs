using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Search3 : IState
{
    // Search state for the boss enemy type. This is the same as the AI search state we did in the labs.
    EnemyController3 owner;
    NavMeshAgent agent;
    private float Searchtime;
    
    public State_Search3(EnemyController3 owner)
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
            owner.stateMachine.ChangeState(new State_Patrol3(owner));
        }
        
        if (owner.IsTarget)
        {
            Debug.Log("Player Seen Again");
            owner.stateMachine.ChangeState(new State_Attack3(owner));
        }
    }

    public void Exit()
    {
        owner.GreenLightOff();
        Debug.Log("Exit Search State");
    }
}