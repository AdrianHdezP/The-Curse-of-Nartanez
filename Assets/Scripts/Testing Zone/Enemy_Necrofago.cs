using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy_Necrofago : MonoBehaviour
{
    private Player player;
    private UI_Player uiPlayer;
    private GameManager gameManager;
    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private Animator anim;

    [Header("Health Config")]
    [SerializeField] private int health = 1;
    private bool dead = false;

    [HideInInspector] public int damage = 1;
    private int damageMultiplicator = 5;
    private bool isAttacking = false;

    [Header("Kcnockback")]
    [SerializeField] private float kcnockbackForce;
    private bool isKcock = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        uiPlayer = GameObject.Find("Player").GetComponent<UI_Player>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        // Subir la vida cada ronda
        health = 0 + (1 * gameManager.rounds);

        // Subir el daño cada cinco rondas
        if(gameManager.rounds/damageMultiplicator == 1)
        {
            damageMultiplicator = damageMultiplicator + 5;
            damage++;
        }

        // Velocidad aleatoria de cada enemigo
        navMeshAgent.speed = Random.Range(4, 6);
    }

    private void Update()
    {
        if (!dead)
        {
            transform.LookAt(player.transform.position);

            Move();

            Attack();
        }
    }

    private void Move()
    {
        if (isKcock)
            return;
        else if (isAttacking)
            return;
        else
        {
            navMeshAgent.SetDestination(player.transform.position);
            anim.SetFloat("Speed", Mathf.Abs(navMeshAgent.velocity.x + navMeshAgent.velocity.z));
        }
    }

    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 2)
        {
            isAttacking = true;
            anim.SetBool("Attack", true);
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                isAttacking = false;
                anim.SetBool("Attack", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            other.GetComponent<Player>().ReciveDamage(damage);
        }
    }

    public void ReciveDamage(int _normalDamage, int _zombieDamage)
    {
        health -= _normalDamage + _zombieDamage;

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        dead = true;
        gameManager.necrofagosLeftInRound--;
        uiPlayer.coinValue += 100;
        Destroy(gameObject);
    }

    #region Kcnockback
    public void Kcnockback() => StartCoroutine(DoKcnocback());
    public IEnumerator DoKcnocback()
    {
        anim.SetBool("Kcnocked", true);
        isKcock = true;
        rb.isKinematic = false;
        navMeshAgent.enabled = false;

        rb.AddForce(player.moveDirection.normalized * kcnockbackForce, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("Kcnocked", false);
        isKcock = false;
        rb.isKinematic = true;
        navMeshAgent.enabled = true;
    }
    #endregion

}
