using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastBehavior : MonoBehaviour
{

    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        Vector3 targetPosition = player.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);

        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
