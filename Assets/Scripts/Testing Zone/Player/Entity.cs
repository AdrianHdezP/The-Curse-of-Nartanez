using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Ground Check")]
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected bool isGrounded;

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
 
    }

    #region Collisions
    public virtual void WhatIsGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, whatIsGround);
    }
    #endregion

}
