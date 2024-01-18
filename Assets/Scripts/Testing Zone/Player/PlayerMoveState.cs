using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        player.Walk();

        player.uiPlayer.IncreaseStamina();

        // Otra manera de caminar es utilizando la velocity(El handicap es la camara)
        //player.SetVelocity(horizontalInput * 5, rb.velocity.y, verticalInput * 5);

        if (horizontalInput == 0 && verticalInput == 0)
            statemachine.ChangeState(player.idleState);
    }
}
