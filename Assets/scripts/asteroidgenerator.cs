using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidgenerator : MonoBehaviour
{
    public GameObject[] asteroida;
    public GameObject asteroida_upgrade;
    public bool stopSpawning = false;
    private float spawnTime = 0f;
    public float spawnDelay = 6f;

    public void Start()
    {
        InvokeRepeating("SpawnUpgradedAsteroid", 8f, 18f);
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        int rand = Random.Range(0, asteroida.Length);
        Instantiate(asteroida[rand], transform.position, Quaternion.identity);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

    private void SpawnUpgradedAsteroid()
    {
        Instantiate(asteroida_upgrade);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}

