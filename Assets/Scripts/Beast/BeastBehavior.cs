using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float fightDistance = 1.7f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GameObject toInteract = (target == null ? player : target);

        Vector3 targetPosition = toInteract.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);

        transform.Translate(Vector3.right * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, toInteract.transform.position);
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
        if (!AnimatorIsPlaying("Benji_Attack"))
        {
            animator.Play("Benji_Attack");
        }
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }

    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
