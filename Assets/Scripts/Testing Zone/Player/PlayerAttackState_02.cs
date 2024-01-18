using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState_02 : PlayerState
{
    public PlayerAttackState_02(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && clicked <= 0)
        {
            clicked = 0;
            statemachine.ChangeState(player.idleState);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            clicked++;
            //Debug.Log(clicked);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && clicked >= 1)
            statemachine.ChangeState(player.attackState3);

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            clicked = 0;
            //Debug.Log(clicked);
        }
    }
}
