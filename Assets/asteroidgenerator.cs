using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidgenerator : MonoBehaviour
{
    public GameObject[] asteroida;
    public bool stopSpawning = false;
    private float spawnTime = 4f;
    public float spawnDelay = 6f;

    public void Start()
    {
        
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
}

