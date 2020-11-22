using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float fightDistance = 1.7f;
    public float speed = 4f;
    public float leashDistance = 1.0f;

    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GameObject toInteract = (target == null ? player : target);

        Vector3 targetPosition = toInteract.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        if (transform.position.x > targetPosition.x)
        {
            spriteRenderer.flipX = false;
        } 
        else
        {
            spriteRenderer.flipX = true;
        }


        float distance = Vector3.Distance(transform.position, toInteract.transform.position);

        if (toInteract == player)
        {
            if (distance >= leashDistance)
            {
                transform.Translate(direction * Time.deltaTime * speed);
            }
            else
            {
                // Don't move too close to player
            }
        }
        else
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }

        if (toInteract == target && distance <= fightDistance)
        {
            Attack(target);
        }
    }

    public void SetTarget(GameObject toTarget)
    {
        target = toTarget;
    }

    public void Attack(GameObject toTarget)
    {
        if (!Tools.AnimatorIsPlaying(animator, "Benji_Attack"))
        {
            animator.Play("Benji_Attack");
        }
    }
}
