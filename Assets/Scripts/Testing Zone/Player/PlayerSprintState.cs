using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerGroundedState
{
    public PlayerSprintState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        player.Sprint();

        player.uiPlayer.DecreaseStamina();

        if (!Input.GetKey(KeyCode.LeftShift))
            statemachine.ChangeState(player.idleState);

        if (horizontalInput == 0 && verticalInput == 0)
            statemachine.ChangeState(player.idleState);

        if (stamina <= 0)
            statemachine.ChangeState(player.moveState);
    }
}
