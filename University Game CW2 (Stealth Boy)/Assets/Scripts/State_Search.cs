using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Search : IState
{
    // Search state for the runner enemy type. Same search state we did within the labs.
    EnemyController1 owner;
    NavMeshAgent agent;
    private float Searchtime;
    
    public State_Search(EnemyController1 owner)
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
            owner.stateMachine.ChangeState(new State_Patrol(owner));
        }
        
        if (owner.IsTarget == true)
        {
            Debug.Log("Player Seen Again");
            owner.stateMachine.ChangeState(new State_Attack(owner));
        }
    }

    public void Exit()
    {
        owner.GreenLightOff();
        Debug.Log("Exit Search State");
    }
}
