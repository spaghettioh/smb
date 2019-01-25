using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMover : MonoBehaviour {
    public int moveSpeed = 5;
    public bool moveRight = true;
    private int moveDirection;
    public Rigidbody2D body;

    private void Start()
    {
        if (moveRight)
            moveDirection = 1;
        else
            moveDirection = -1;
    }

    // Update is called once per frame
    void Update ()
    {
        RaycastHit2D turnAround = Physics2D.Raycast(transform.position, new Vector2(moveDirection, 0));
        body.velocity = new Vector2(moveDirection * moveSpeed, body.velocity.y);

        // Bounce off objects
        if (turnAround.distance < .7f && turnAround.collider.name != "Player")
            moveDirection *= -1;
	}
}
