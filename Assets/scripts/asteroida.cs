using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroida : MonoBehaviour
{
    private int life = 3;
    public Transform target;
    public float asteroidspeed;

    [SerializeField] private ParticleSystem destroy;
    [SerializeField] private PlanetHP _planethp;
    [SerializeField] private asteroidgenerator _asteroidgenerator;

    private void Start()
    {
        asteroidspeed = 0.1f;

        Vector3 randomSpawnPosition = new Vector3(Random.Range(-100, 110), Random.Range(-100, 110), Random.Range(-100, 110));
        transform.position = randomSpawnPosition;
        
        _planethp = GameObject.FindWithTag("planeta").GetComponent<PlanetHP>();
        _asteroidgenerator = GameObject.FindWithTag("GameController").GetComponent<asteroidgenerator>();
    }
    private void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a, b, asteroidspeed);
    }

    private void Update()
    {
        PlanetState();
    }

    private void PlanetState()
    {
        GameObject.FindWithTag("asteroida").GetComponent<asteroida>();
        if (_planethp._CurrentHealth <= 70 && _planethp._CurrentHealth > 50)
        {
            asteroidspeed = 0.2f;
            _asteroidgenerator.spawnDelay = 5.5f;
        }
        if (_planethp._CurrentHealth <= 50 && _planethp._CurrentHealth > 20)
        {
            asteroidspeed = 0.3f;
            _asteroidgenerator.spawnDelay = 5f;
        }
        else
        {
            asteroidspeed = 0.4f;
            _asteroidgenerator.spawnDelay = 3f;
        }
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
            Instantiate(destroy, transform.position, Quaternion.identity);
        }
        if(life == 0)
        {
            Destroy(gameObject);
            Instantiate(destroy, transform.position, Quaternion.identity);
        }
    }
}
