using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;
    //private float moveInput;
    private bool isGrounded;
    private int extraJumps;
    private bool facingRight = true;

    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    public Transform groundCheck;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Jump
        if ((Input.GetKey("up") || Input.GetKey("w")) && isGrounded)
        {
            //playerRigidBody.AddForce((Vector2.up) * jumpForce, ForceMode2D.Impulse);
            //playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            playerRigidBody.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        //Movement
        //moveInput = Input.GetAxis("Horizontal");
        //playerRigidBody.velocity = new Vector2(moveInput * movementSpeed, playerRigidBody.velocity.y);

        //if (moveInput > 0)
        //{
        //    playerSpriteRenderer.flipX = false;
        //}
        //else if (moveInput < 0)
        //{
        //    playerSpriteRenderer.flipX = true;
        //}

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if (mousePosition.x < playerScreenPoint.x )
            {
                playerRigidBody.velocity = new Vector2(movementSpeed, playerRigidBody.velocity.y);
                //playerSpriteRenderer.flipX = false;   //Only works for the graphics, not the rigidbody or children
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                playerRigidBody.velocity = new Vector2(movementSpeed, playerRigidBody.velocity.y);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if (mousePosition.x > playerScreenPoint.x )
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                playerRigidBody.velocity = new Vector2(-(movementSpeed), playerRigidBody.velocity.y);
            }
            else
            {
                playerRigidBody.velocity = new Vector2(-(movementSpeed), playerRigidBody.velocity.y);
                //playerSpriteRenderer.flipX = true;    //Only works for the graphics, not the rigidbody or children
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
        else
        {
            playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
        }

    }
}
