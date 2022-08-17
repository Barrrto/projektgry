using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroida_upgrade : MonoBehaviour
{

    private int life = 6;
    public Transform target;
    public float asteroidspeed = 0.2f;

    [SerializeField] private ParticleSystem destroy;
    [SerializeField] private fpscap _bullet;
    private ParticleSystem particle;
    private void Start()
    {
        particle = GameObject.Find("fire_another").GetComponent<ParticleSystem>();
        _bullet = GameObject.Find("gamemanager").GetComponent<fpscap>();
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
            life = life - _bullet.bulletdmg;
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
