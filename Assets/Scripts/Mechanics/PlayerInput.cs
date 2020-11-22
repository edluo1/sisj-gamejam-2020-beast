using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer spriteRenderer;

    float horizontal;
    float vertical;
    bool attackOrder;
    float moveLimiter = 0.7071f;

    public float runSpeed = 20.0f;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    { 
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        attackOrder = Input.GetKeyDown(KeyCode.LeftControl); // change this later
    } 

    void FixedUpdate()
    {
        handleMovement();
        handleAttackOrder();
    }

    void handleMovement() {
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetTrigger("isMoving");
        } 
        else
        {
            animator.ResetTrigger("isMoving");
        }

        if (horizontal > 0.1)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < -0.1)
        {
            spriteRenderer.flipX = true;
        }

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void handleAttackOrder() {
        if (attackOrder) {
            animator.Play("Player_Attack");
        }
    }
}
