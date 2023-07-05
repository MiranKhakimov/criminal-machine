using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Animator anim;
    public SpriteRenderer sr;

    private bool atGround;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }  

    void Update()
    {
        Jump();
        Reflect();
    }

    void FixedUpdate()
    {
        Move();    
    }

    public Vector2 moveVector;
    void Move()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
    }

    void Jump()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Reflect()
    {
        sr.flipX = moveVector.x < 0;
    }

}
    