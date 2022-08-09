using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroida : MonoBehaviour
{
    private int life = 3;
    public Transform target;

    private void Start()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-100, 110), Random.Range(-100, 110), Random.Range(-100, 110));
        transform.position = randomSpawnPosition;
    }
    private void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a, b, 0.1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("bullet"))
        {
            life--;
        }
        if(other.CompareTag("planeta"))
        {
            Destroy(gameObject);
        }
        if(life == 0)
        {
            Destroy(gameObject);
        }
    }
}
