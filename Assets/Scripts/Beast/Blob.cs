using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.Translate(direction * Time.deltaTime * movementSpeed);
    }
}
