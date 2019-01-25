﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float size;
    public bool grounded = true;
    public bool invincible = false;
    public IntVariable lives;
    public IntVariable score;

    [Header("Controls")]
    public float moveSpeed = 5;
    public float jumpForce = 5;
    public Rigidbody2D body;

    [Header("Events")]
    public GameEvent died;
    public GameEvent hurt;

    [Header("Debug")]
    public string message;
    public int livesDebug = 0;
    public int scoreDebug = 0;
    public float inputHorizontal = 0;
    public float moveDirection = 1;
    public float distToGround = 0;


    Animator anim;

    // Use this for initialization
    void Start ()
    {
        // Setup the player
        anim = gameObject.GetComponent<Animator>();

        // Reset some variables
        size = 0;
        grounded = true;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        livesDebug = lives.Value;
        scoreDebug = score.Value;

        // Grab directional input
        inputHorizontal = Input.GetAxis("Horizontal");

        // Move
        Move();

        // Let the animator know what's going on...
        Animate();

        // Check if on a ground
        //IsGrounded();

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.AddForce(Vector2.up * jumpForce);
            grounded = false;
        }

        // SIZE ============
        // Correct size value
        if (size > 2)
        {
            size = 2;
        }
        // ===============
    }

    void Move()
    {
        if (Mathf.Abs(inputHorizontal) > 0)
        {
            // grab scale to invert direction
            Vector3 scale = transform.localScale;

            if (inputHorizontal < 0)
            {
                scale.x = -1;
                moveDirection = -1;
            }
            else
            {
                scale.x = 1;
                moveDirection = 1;
            }

            body.velocity = new Vector2(moveSpeed * moveDirection, body.velocity.y);
            transform.localScale = scale;
        }
    }

    void Animate()
    {
        // ...what size you are
        anim.SetFloat("Size", size);

        // ...how fast you're going
        anim.SetFloat("MoveSpeed", Mathf.Abs(body.velocity.x));

        // ...if you're in the air
        float inAir;
        if (grounded)
        {
            inAir = 0;
        }
        else
        {
            inAir = 1;
        }
        anim.SetFloat("InAir", inAir);

        // ...if you're dead
        if (size < 0)
        {
            anim.SetTrigger("Die");
            died.Raise();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}