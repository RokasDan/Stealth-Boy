using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Search4 : IState
{
    // Search state for the turret enemy type. This is the same AI search state as the one we did in the labs.
    EnemyController4 owner;
    NavMeshAgent agent;
    private float Searchtime;
    
    public State_Search4(EnemyController4 owner)
    {
        this.owner = owner;
    }
    
    
    public void Enter()
    {
        owner.GreenLightOn();
        Debug.Log("Entering Search State");
        agent = owner.GetComponent<NavMeshAgent>();

        

        Searchtime = Time.time;

    }

    public void Execute()
    {
        owner.TurretAttack();
        if (Time.time > Searchtime + owner.SearchTime)
        {
            owner.stateMachine.ChangeState(new State_Patrol4(owner));
        }
        
        if (owner.IsTarget)
        {
            Debug.Log("Player Seen Again");
            owner.stateMachine.ChangeState(new State_Attack4(owner));
        }
    }

    public void Exit()
    {
        owner.GreenLightOff();
        Debug.Log("Exit Search State");
    }
}
