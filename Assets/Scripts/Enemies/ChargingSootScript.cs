using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SootEnemyState
{
    Search,
    Charge,
    Attack,
    Recharge
}

public class ChargingSootScript : MonoBehaviour
{
    Vector2 chargeDirection;
    public GameObject target; // who to target
    public float inRange = 2f; // when player is in range
    public float moveSpeed = 1f;

    public float rechargeTime = 4f;

    Animator animator;
    SootEnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        state = SootEnemyState.Search;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case SootEnemyState.Search:
                Vector3 targetPosition = target.transform.position;
                Vector3 direction = (targetPosition - transform.position).normalized;
                transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

                if (Vector3.Distance(targetPosition, transform.position) <= inRange)
                {
                    chargeDirection = new Vector2(transform.position.x - targetPosition.x, transform.position.y - targetPosition.y);
                    state = SootEnemyState.Attack;
                }
                break;
            case SootEnemyState.Attack:
                if (!Tools.AnimatorIsPlaying(animator, "Soot_Attack"))
                {
                    animator.Play("Soot_Attack");
                }
                else
                {
                    state = SootEnemyState.Search;
                }
                break;
        } 
    }
}
