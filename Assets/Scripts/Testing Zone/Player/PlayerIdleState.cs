using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        player.uiPlayer.IncreaseStamina();

        if (!player.dead)
        {
            if (horizontalInput != 0)
                statemachine.ChangeState(player.moveState);
            else if (verticalInput != 0)
                statemachine.ChangeState(player.moveState);
        }
    }
}
