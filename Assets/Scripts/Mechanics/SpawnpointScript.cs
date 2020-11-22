using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointScript : MonoBehaviour
{
	public GameObject toSpawn;

	// spawnpoint for the character
	// not for the enemy that's called the spawner
    // Start is called before the first frame update
    void Start()
    {
        string tag = toSpawn.tag;
        GameObject[] allToSpawn = GameObject.FindGameObjectsWithTag(tag);
        if (allToSpawn.Length <= 0) {
        	Instantiate(toSpawn, transform.position, transform.rotation);
        } else {
        	allToSpawn[0].transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
