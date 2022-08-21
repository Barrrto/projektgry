using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerups;
    public bool stopSpawning = false;
    private float spawnTime = 0f;
    private float spawnDelay = 10f;
    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    private void Spawn()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
        transform.position = randomSpawnPosition;

        int rand = Random.Range(0, powerups.Length);
        Instantiate(powerups[rand], transform.position, Quaternion.identity);

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
