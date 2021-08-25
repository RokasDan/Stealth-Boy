using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Damaged2 : IState
{
    // Damaged state for the gunner enemy type. This state makes the enemy turn to the player once 
    // it was hit during the patrol state. This state acts the same as the search state from the labs.
    // It only doesn't tell the game controller that it is searching for the player once it is active.
    EnemyController2 owner;
    NavMeshAgent agent;
    private float Searchtime;
    
    public State_Damaged2(EnemyController2 owner)
    {
        this.owner = owner;
    }
    
    
    public void Enter()
    {
        Debug.Log("Entering Damaged");
        agent = owner.GetComponent<NavMeshAgent>();
        
        agent.destination = owner.Player.transform.position;
        agent.isStopped = false;
        Searchtime = Time.time;

    }

    public void Execute()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.isStopped = false;
        }

        if (Time.time > Searchtime + 5)
        {
            owner.stateMachine.ChangeState(new State_Patrol2(owner));
        }
        
        if (owner.IsTarget)
        {
            Debug.Log("Player Seen Again");
            owner.stateMachine.ChangeState(new State_Attack2(owner));
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Damaged State");
    }
}