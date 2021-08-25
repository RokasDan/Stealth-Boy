using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Attack4 : IState
{
    // Attack state from the AI labs for the turret enemy type.
    EnemyController4 owner;

    public State_Attack4(EnemyController4 owner)
    {
        this.owner = owner;
    }
    
    
    public void Enter()
    {
        Debug.Log("Entering Attack State");
        if (owner.IsTarget)
        {
            owner.RedLightOn();
        }
    }

    public void Execute()
    {
        owner.TurretAttack();
        owner.Fire();

        if (owner.IsTarget != true)
        {
            Debug.Log("Lost the player");
            owner.stateMachine.ChangeState(new State_Search4(owner));
        }
    }

    public void Exit()
    {
        owner.RedLightOff();
        Debug.Log("Exit Attack State");
    }
}