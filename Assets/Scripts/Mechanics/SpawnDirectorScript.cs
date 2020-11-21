using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySet
{
    public GameObject[] enemySet;
}

public class SpawnDirectorScript : MonoBehaviour
{
    public GameObject spawnerObject;

    public EnemySet[] enemySets; // Spawn these enemies
    public Vector2[] spawnLocations; // at these locations

    int currentWave;
    int enemiesLeft;
    bool waveStarted; // track if first wave spawned
    bool roomCleared;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 0;
        enemiesLeft = 0;
        waveStarted = false;
        roomCleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waveStarted)
        {
            SummonEnemies();
            waveStarted = true;
        }
        else
        {
            if (enemiesLeft <= 0 && !roomCleared)
            {
                SummonNextEnemySet();
            }
        }
    }

    public void SummonEnemies()
    {
        if (currentWave < enemySets.Length)
        {
            GameObject[] currentEnemySet = enemySets[currentWave].enemySet;
            foreach (GameObject enemy in currentEnemySet)
            {
                Vector2 spawnLocation = spawnLocations[enemiesLeft % spawnLocations.Length];
                SpawnWithData(enemy, spawnLocation);
                enemiesLeft += 1; // need to find a way to update this in case we have some sort of splitting enemy
            }
        } 
        else
        {
            Debug.Log("Room cleared!");
            roomCleared = true;
        }
    }

    // Summon next set of enemies
    public void SummonNextEnemySet()
    {
        currentWave += 1;
        SummonEnemies();
    }

    // Enemy reports its death to this GameObject
    public void ReportDeath()
    {
        enemiesLeft -= 1;
    }

    public GameObject SpawnWithData(GameObject enemyToSpawn, Vector2 location)
    {
        Vector3 location3 = location;
        GameObject spawner = Instantiate(spawnerObject, location3, transform.rotation) as GameObject;
        spawner.GetComponent<SpawnerScript>().objectToSpawn = enemyToSpawn;
        return spawner;
    }
}
