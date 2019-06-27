using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;

    [SerializeField] float jumpForce = 10;

    bool isJumping;

    public Vector2 JumpVelocity
    {
        get;
        set;
    }
    
    public Vector2 OriginalVelocity
    {
        get;
        set;
    }

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        JumpVelocity = new Vector2 (0, jumpForce);
    }

    void FixedUpdate()
    {
        if(rb2D.velocity == OriginalVelocity)
        {
            isJumping = false;
        }
    }

    void Update()
    {
        if(!isJumping)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if(Input.touchCount > 0)
        {   
            isJumping = true;
            OriginalVelocity = rb2D.velocity;
            Debug.Log("jump");
            rb2D.velocity = JumpVelocity;
        }else if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            OriginalVelocity = rb2D.velocity;
            Debug.Log("jump");
            rb2D.velocity = JumpVelocity;
        }
    }
}
