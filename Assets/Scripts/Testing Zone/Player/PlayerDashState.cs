using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerGroundedState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (player.gobron == true)
        {
            player.GobronDash();
        }

        if (player.imAshud == true)
        {
            player.GoTransparent();
            player.ImAshudDash();
            capsuleCollider.enabled = false;
            player.colliderDash.SetActive(true);
        }

        if (player.astir == true)
        {
            player.AstirDash();
            capsuleCollider.enabled = false;
            player.colliderDash.SetActive(true);
        }
    }

    public override void Exit()
    {
        base.Exit();  
    }

    public override void Update()
    {
        base.Update();

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.3f)
        {
            if (player.gobron == true)
            {
                player.timer = cooldown;

                if (horizontalInput != 0)
                    statemachine.ChangeState(player.moveState);
                else if (verticalInput != 0)
                    statemachine.ChangeState(player.moveState);
                else if (horizontalInput == 0 && verticalInput == 0)
                    statemachine.ChangeState(player.idleState);
            }

            if (player.imAshud == true)
            {
                player.BackTransparent();
                capsuleCollider.enabled = true;
                player.colliderDash.SetActive(false);

                player.timer = cooldown;

                if (horizontalInput != 0)
                    statemachine.ChangeState(player.moveState);
                else if (verticalInput != 0)
                    statemachine.ChangeState(player.moveState);
                else if (horizontalInput == 0 && verticalInput == 0)
                    statemachine.ChangeState(player.idleState);
            }

            if (player.astir == true)
            {
                capsuleCollider.enabled = true;
                player.colliderDash.SetActive(false);

                player.timer = cooldown;

                if (horizontalInput != 0)
                    statemachine.ChangeState(player.moveState);
                else if (verticalInput != 0)
                    statemachine.ChangeState(player.moveState);
                else if (horizontalInput == 0 && verticalInput == 0)
                    statemachine.ChangeState(player.idleState);
            }
        }
    }
}
