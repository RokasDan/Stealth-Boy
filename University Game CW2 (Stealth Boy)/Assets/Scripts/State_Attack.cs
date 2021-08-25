using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Attack: IState
{
    // Attack state from the AI labs for the runner enemy type.
    EnemyController1 owner;
    NavMeshAgent agent;
    private float EnemySpottedSpeed = 20f;
    private float EnemyLostSpeed = 3.5f;
    private float EnemySpottedAngular = 120f;
    private float EnemyLostAngular = 120f;
    
    
    public State_Attack(EnemyController1 owner)
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
            agent.speed = EnemySpottedSpeed;
            agent.angularSpeed = EnemySpottedAngular;
            agent.isStopped = false;
        }
        
    }

    public void Execute()
    {
        agent.destination = owner.lastSeenPosition;
        agent.isStopped = false;
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.isStopped = false;
        }

        if (owner.IsTarget != true)
        {
            Debug.Log("Lost the player");
            owner.stateMachine.ChangeState(new State_Search(owner));
        }
        
    }

    public void Exit()
    {
        owner.RedLightOff();
        Debug.Log("Exit Attack State");
        agent.speed = EnemyLostSpeed;
        agent.angularSpeed = EnemyLostAngular;
        agent.isStopped = true;
    }
}
