using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeavyAttackState : PlayerState
{
    public PlayerHeavyAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            statemachine.ChangeState(player.idleState);
    }
}
