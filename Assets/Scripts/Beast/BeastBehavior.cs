using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float fightDistance = 1.7f;

    void Start()
    {

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
        // Debug.Log("Pow!");
    }
}
