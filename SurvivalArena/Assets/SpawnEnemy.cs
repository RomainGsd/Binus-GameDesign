using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    int randomSpawnSpoint, randomEnemy;
    public static bool spawnAllowed;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("spawnAnEnemy", 0f, 0.5f);
    }

    void spawnAnEnemy()
    {
        if (spawnAllowed)
        {
            randomSpawnSpoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnSpoint].position, Quaternion.identity);
        }
    }
}
