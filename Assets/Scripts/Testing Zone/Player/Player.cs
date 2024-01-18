using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DashType
{
    Gobron,
    ImAshud,
    Astir
}

public class Player : Entity
{
  
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody rb { get; private set; }
    public CapsuleCollider capsuleCollider { get; private set; }
    public SkinnedMeshRenderer smr { get; private set; }
    public UI_Player uiPlayer { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState        idleState        { get; private set; }
    public PlayerMoveState        moveState        { get; private set; }
    public PlayerSprintState      sprintState      { get; private set; }
    public PlayerAttackState_01   attackState1     { get; private set; }
    public PlayerAttackState_02   attackState2     { get; private set; }
    public PlayerAttackState_03   attackState3     { get; private set; }
    public PlayerHeavyAttackState heavyAttackState { get; private set; }
    public PlayerDashState        dashState        { get; private set; }
    #endregion

    #region Stats
    [HideInInspector] public bool dead = false;
    [HideInInspector] public int health;
    #endregion

    private float horizontalInput;
    private float verticalInput;

    [Header("Movement Config")]
    [SerializeField]  private float walkSpeed;
    [SerializeField]  private float sprintSpeed;
    [SerializeField]  private Transform orientation;
    [HideInInspector] public Vector3 moveDirection;
    [HideInInspector] private float groundDrag = 5;
    
    [Header("Dash Config")]
    public DashType dashType;
    [HideInInspector] public bool gobron = false;
    [HideInInspector] public bool imAshud = false;
    [HideInInspector] public bool astir = false;
    [Space(15)]
    [SerializeField]  public GameObject colliderDash;
    [SerializeField]  public GameObject cameras;
    [SerializeField]  public float timer;
    [SerializeField]  public int cooldown;
    [SerializeField] [Range(10, 30)] private float gobronDashForce;
    [SerializeField] [Range(30, 50)] private float imAshudDashForce;
    [SerializeField] [Range(10, 30)] private float astirDashForce;

    // En el awake se inicializan los estados
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState        = new PlayerIdleState       (this, stateMachine, "Idle");
        moveState        = new PlayerMoveState       (this, stateMachine, "Move");
        sprintState      = new PlayerSprintState     (this, stateMachine, "Sprint");
        attackState1     = new PlayerAttackState_01  (this, stateMachine, "Attack01");
        attackState2     = new PlayerAttackState_02  (this, stateMachine, "Attack02");
        attackState3     = new PlayerAttackState_03  (this, stateMachine, "Attack03");
        heavyAttackState = new PlayerHeavyAttackState(this, stateMachine, "HeavyAttack");
        dashState        = new PlayerDashState       (this, stateMachine, "Dash");
    }

    // En el start se inicializan los componentes
    public override void Start()
    {
        base.Start();

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        smr = GetComponentInChildren<SkinnedMeshRenderer>();
        uiPlayer = GetComponent<UI_Player>();

        stateMachine.Initialize(idleState);

        health = 10;

        // Seleccion del tipo de dash segun los personajes
        #region SelectDash
        switch (dashType)
        {
            case DashType.Gobron:
                gobron = true;
                imAshud = false;
                astir = false;
                break;
            case DashType.ImAshud:
                gobron = false;
                imAshud = true;
                astir = false;
                break;
            case DashType.Astir:
                gobron = false;
                imAshud = false;
                astir = true;
                break;
            default:
                break;
        }
        #endregion
    }

    public override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();

        Debug.Log(health);
        
        PlayerInput();

        WhatIsGround();

        // Control Drag
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    #region Inputs
    public virtual void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    #endregion

    #region MovePlayer
    public void SetVelocity(float _xVelocity, float _yVelocity, float _zVelocity)
    {
        // Otra manera de caminar es utilizando la velocity(El handicap es la camara)
        rb.velocity = new Vector3(_xVelocity, _yVelocity, _zVelocity);
    }

    public virtual void Walk()
    {
        // Otra manera de caminar es utilizando la fuerza(El handicap es el Vsync)
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * walkSpeed, ForceMode.Force);
    }

    public virtual void Sprint()
    {
        // Otra manera de caminar es utilizando la fuerza(El handicap es el Vsync)
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * sprintSpeed, ForceMode.Force);
    }
    #endregion

    #region Dash
    public virtual void GobronDash()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * gobronDashForce, ForceMode.Impulse);
    }
    public virtual void ImAshudDash()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * imAshudDashForce, ForceMode.Impulse);

    }
    public virtual void AstirDash()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * astirDashForce, ForceMode.Impulse);
    }
    #endregion

    #region Damage
    public void ReciveDamage(int _damage)
    {
        health -= _damage;

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        dead = true;
        Destroy(gameObject);
    }
    #endregion

    #region Collisions
    public void OnCollisionEnter(Collision collision)
    {
        if (dashType == DashType.Gobron && anim.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
        {
            if (collision.gameObject.GetComponent<Enemy_Necrofago>() == null)
                return;
            else
                collision.gameObject.GetComponent<Enemy_Necrofago>().Kcnockback();
        }
    }
    #endregion

    #region FX
    public virtual void GoTransparent() => smr.enabled = false;
    public virtual void BackTransparent() => smr.enabled = true;
    #endregion

}
