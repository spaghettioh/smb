using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FloatVariable size;
    public FloatVariable moveSpeed;
    public FloatVariable jumpForce;
    public Rigidbody2D body;
    public bool grounded = true;

    public float inputHorizontal = 0;
    public float moveDirection = 1;
    public float distToGround = 0;

    public string debug;
 
    Animator anim;

    // Use this for initialization
    void Start ()
    {
        size.Value = 0;
        grounded = true;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        // Check for player directional input
        inputHorizontal = Input.GetAxis("Horizontal");

        // Move
        Move();

        // Let the animator know what's going on...
        Animate();

        // Check if on a ground
        IsGrounded();

        // Jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce.Value);
        }

    }

    public bool IsGrounded()
    {
        if (body.velocity.y > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
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

            body.velocity = new Vector2(moveSpeed.Value * moveDirection, body.velocity.y);
            transform.localScale = scale;
        }
    }

    void Animate()
    {
        // ...what size you are
        anim.SetFloat("Size", size.Value);
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
    }

    //void OnTriggerStay2D(Collision collision)
    //{
    //    foreach (ContactPoint contact in collision.contacts)
    //    {
    //        if (contact.thisCollider.isTrigger && collision.gameObject.layer == 12)
    //        {
    //            inAir = 0;
    //        }
    //    }
    //}
}