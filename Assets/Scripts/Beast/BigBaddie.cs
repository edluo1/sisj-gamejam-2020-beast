using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBaddie : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed = 1f;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.Translate(direction * Time.deltaTime * movementSpeed);

        if (transform.position.x > targetPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
