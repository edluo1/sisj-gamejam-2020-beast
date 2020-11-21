using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float timeToSpawn = 2f;
    public float spinToAngle = -900f;
    float timeRemaining;

    SpriteRenderer spriteRenderer;

    public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeToSpawn;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        float normalizedElapsedTime = 1 - (timeRemaining / timeToSpawn);
        transform.eulerAngles = new Vector3(0, 0, getSpin(normalizedElapsedTime));
        spriteRenderer.color = new Color(normalizedElapsedTime, 0, 0);
        if (timeRemaining <= 0)
        {
            if (objectToSpawn)
            {
                Instantiate(objectToSpawn, transform.position, new Quaternion(0, 0, 0, 0));
            }
            Destroy(gameObject);
        }
    }

    // Set the rotation angle of the spawner.
    // Input between 0 and 1, with 0 being at the beginning and 1 being the spawn time.
    float getSpin(float elapsedTime)
    {
        return 0.5f * spinToAngle * elapsedTime * elapsedTime;
    }
}
