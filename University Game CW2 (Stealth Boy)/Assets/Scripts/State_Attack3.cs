using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Attack3 : IState
{
    // Attack state from the AI labs for the boss enemy type.
    EnemyController3 owner;
    NavMeshAgent agent;
    
    public State_Attack3(EnemyController3 owner)
    {
        this.owner = owner;
    }
    
    
    public void Enter()
    {
        
        Debug.Log("Entering Attack State");
        agent = owner.GetComponent<NavMeshAgent>();
        
        

        if (owner.IsTarget)
        {
            owner.RedLightOn();
            agent.destination = owner.lastSeenPosition;
            agent.isStopped = false;
        }
        
    }

    public void Execute()
    {
        agent.destination = owner.lastSeenPosition;
        agent.isStopped = false;

        if (!agent.pathPending && agent.remainingDistance < 5f)
        {
            agent.isStopped = true;
        }
        
        owner.Fire();

        if (owner.IsTarget != true)
        {
            Debug.Log("Lost the player");
            owner.stateMachine.ChangeState(new State_Search3(owner));
        }
        
    }

    public void Exit()
    {
        owner.RedLightOff();
        Debug.Log("Exit Attack State");
        agent.isStopped = true;
    }
}
