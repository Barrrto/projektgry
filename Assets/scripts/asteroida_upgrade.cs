using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroida_upgrade : MonoBehaviour
{

    private int life = 5;
    public Transform target;
    public float asteroidspeed;

    [SerializeField] private ParticleSystem destroy;
    private void Start()
    {
        asteroidspeed = 0.1f;

        Vector3 randomSpawnPosition = new Vector3(Random.Range(-100, 110), Random.Range(-100, 110), Random.Range(-100, 110));
        transform.position = randomSpawnPosition;
    }
    private void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a, b, asteroidspeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            life--;
        }
        if (other.CompareTag("planeta"))
        {
            Destroy(gameObject);
            Instantiate(destroy, transform.position, Quaternion.identity);
        }
        if (life == 0)
        {
            Destroy(gameObject);
            Instantiate(destroy, transform.position, Quaternion.identity);
        }
    }
}
