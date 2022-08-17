using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroida : MonoBehaviour
{
    private int life = 3;
    public Transform target;
    private float asteroidspeed = 0.2f;
    
    [SerializeField] private ParticleSystem destroy;
    [SerializeField] private PlanetHP _planethp;
    [SerializeField] private asteroidgenerator _asteroidgenerator;
    [SerializeField] private fpscap _bullet2;
    private ParticleSystem particle;

    
    private void Start()
    {   
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-100, 110), Random.Range(-100, 110), Random.Range(-100, 110));
        transform.position = randomSpawnPosition;

        _planethp = GameObject.FindWithTag("planeta").GetComponent<PlanetHP>();
        _asteroidgenerator = GameObject.FindWithTag("GameController").GetComponent<asteroidgenerator>();
        particle = GameObject.Find("fire").GetComponent<ParticleSystem>();
        _bullet2 = GameObject.Find("gamemanager").GetComponent<fpscap>();
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
            asteroidspeed = 0.3f;
            _asteroidgenerator.spawnDelay = 5.5f;
        }
        if (_planethp._CurrentHealth <= 50 && _planethp._CurrentHealth > 20)
        {
            asteroidspeed = 0.4f;
            _asteroidgenerator.spawnDelay = 5f;
        }
        if(_planethp._CurrentHealth <= 20 && _planethp._CurrentHealth > 0)
        {
            asteroidspeed = 0.5f;
            _asteroidgenerator.spawnDelay = 4f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            life = life - _bullet2.bulletdmg;
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

    IEnumerator color()
    {
        yield return new WaitForSeconds(5f);
        particle.startColor = Color.red;
    }

    public void colorchange()
    {
        particle.startColor = new Color32(61, 178, 236, 255);
        StartCoroutine(color());
    }

    IEnumerator freeze1()
    {
        yield return new WaitForSeconds(5f);
        asteroidspeed = 0.2f;
    }

    public void freeze2()
    {
        asteroidspeed = 0;
        StartCoroutine(freeze1());
    }
}
