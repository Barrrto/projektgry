using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;
    [SerializeField] private ParticleSystem destroypart;
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("asteroida"))
        {
            Destroy(gameObject);
            ParticleDestroy();
        }
        if(other.CompareTag("asteroida2"))
        {
            Destroy(gameObject);
            ParticleDestroy();
        }
        if(other.CompareTag("planeta"))
        {
            Destroy(gameObject);
            ParticleDestroy();
        }
    }
    private void ParticleDestroy()
    {
        Instantiate(destroypart, transform.position, Quaternion.identity);
    }
}
