using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Vector2 moveVector;
    public GameObject groundChecker;
    public LayerMask ground;
    public Animator anim;

    private bool faceRight;
    private bool atGround;
    private Rigidbody2D rb;

    void Start()
    {
        atGround = true;
        faceRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }  

    void Update()
    {
        GroundCheck();
        Reflect();
        Jump();
    }

    void FixedUpdate()
    {
        Move();    
    }

    void Move()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && atGround)
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
        atGround = Physics2D.OverlapCircle(groundChecker.transform.position, groundChecker.GetComponent<CircleCollider2D>().radius, ground);
    }

}
    