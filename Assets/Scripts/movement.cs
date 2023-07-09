using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Vector2 moveVector;
    public GameObject groundChecker;
    public GameObject character;
    public LayerMask ground;
    public Animator anim;
    public bool faceRight;

    private bool onGround;
    private Rigidbody2D rb;

    protected internal String status;

    void Start()
    {
        onGround = true;
        faceRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GroundCheck();
        
        status = character.GetComponent<Status>().GetFrameStatus();
        moveVector.x = Input.GetAxis("Horizontal");
        if (status == "neutral")
        {
            Reflect();
            Jump();
        }
    }

    void FixedUpdate()
    {
        status = character.GetComponent<Status>().GetFrameStatus();
        
        if (status == "neutral")
        {
            if (onGround)
            {
                Move();
            }
        }
        else
        {
            Input.ResetInputAxes();
        }
    }

    void Move()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && onGround)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void GroundCheck()
    {
        anim.SetBool("onGround", onGround);
        onGround = Physics2D.OverlapCircle(groundChecker.transform.position, groundChecker.GetComponent<CircleCollider2D>().radius, ground);
    }
    
}
    