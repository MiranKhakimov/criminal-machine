using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    public float speed;
    public float flightRange;
    public Transform projectileSender;
    public float startPositionX;

    private Rigidbody2D rigidBody;
    private CapsuleCollider2D collider;
    
    void Start()
    {
        startPositionX = transform.position.x;
        collider = GetComponent<CapsuleCollider2D>(); 
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }

    void Update()
    {
        if (Math.Abs(transform.position.x - startPositionX) > flightRange)
        {
            Destroy(gameObject);
        };
        
        if (collider.IsTouchingLayers())
        {
            Destroy(gameObject);
        };
    }

    public void SetOrientation(bool faceRight)
    {
        int koef = faceRight ? 1 : -1;
        speed *= koef;
        transform.localScale *= new Vector2(koef, 1);
    }
}
