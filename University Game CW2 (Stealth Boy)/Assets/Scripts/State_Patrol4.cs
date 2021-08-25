using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Patrol4 : IState
{
    // Patrol class for the turret enemy type. This state is running the turret patrol function.
    // which alternates the turrets look position between two waypoints.
    // todo: private GameController gameController;
    EnemyController4 owner;

    NavMeshAgent agent;

    public State_Patrol4(EnemyController4 owner)
    {
        this.owner = owner;
    }

    public void Enter()
    {
        // todo: gameController.IncrementSpotted();
        Debug.Log("Entering Patrol State");
    }

    public void Execute()
    {
        owner.TurretPatrol();
        // Transitioning to attack if seen
        if (owner.IsTarget)
        {
            owner.stateMachine.ChangeState(new State_Attack4(owner));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Patrol State");
    }
}