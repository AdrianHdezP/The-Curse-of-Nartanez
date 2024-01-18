using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();

        // Si pulsas Shif y la estamina es mayor o igual a la estamina maxima
        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina >= maxStamina)
            statemachine.ChangeState(player.sprintState);

        if (Input.GetKeyDown(KeyCode.Mouse0) && clicked == 0)
            statemachine.ChangeState(player.attackState1);

        if (Input.GetKeyDown(KeyCode.Mouse1))
            statemachine.ChangeState(player.heavyAttackState);

        if (Input.GetKeyDown(KeyCode.C) && player.timer <= 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            statemachine.ChangeState(player.dashState);
    }
}
