using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected PlayerStateMachine statemachine;
    protected Player player;

    protected Animator anim;
    protected Rigidbody rb;
    protected CapsuleCollider capsuleCollider;

    private string animBoolName;

    protected int clicked = 0;

    protected float cooldown;


    #region Inputs
    protected float horizontalInput;
    protected float verticalInput;
    #endregion

    #region UI
    protected float stamina => player.uiPlayer.stamina;
    protected float maxStamina => player.uiPlayer.maxStamina;
    #endregion

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.statemachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        anim = player.anim;
        rb = player.rb;
        capsuleCollider = player.capsuleCollider;
        cooldown = player.cooldown;
    }

    public virtual void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        player.timer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
}
