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
    bool dodgeOrder;

    bool Dashing;

    public float runSpeed = 10f;
    public float dodgeSpeed = 25f;
    public float dashDuration = 0.25f;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Dashing = false;
    }

    void Update()
    { 
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        attackOrder = Input.GetKeyDown(KeyCode.LeftControl); // change this later
        dodgeOrder = Input.GetKeyDown(KeyCode.Space);
    } 

    void FixedUpdate()
    {
        handleMovement();
        handleAttackOrder();
        handleDodge();
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

        if (!Dashing) { // let coroutine handle it
            body.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;
        }
    }

    void handleAttackOrder() {
        if (attackOrder) {
            animator.Play("Player_Attack");
        }
    }

    void handleDodge() {
        if (dodgeOrder) {
            StartCoroutine(Dodge(body.velocity.normalized));
        }
    }

    IEnumerator Dodge(Vector2 direction) {
        Dashing = true;
        body.velocity = direction * dodgeSpeed;
        transform.Find("Hurtbox").gameObject.GetComponent<HurtboxScript>().active = false;
        yield return new WaitForSeconds(dashDuration);
        Dashing = false;
        transform.Find("Hurtbox").gameObject.GetComponent<HurtboxScript>().active = true;
        yield return null;
    }
}
