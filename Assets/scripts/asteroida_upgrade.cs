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
    [SerializeField] private GAMEOVER _gameover;
    private ParticleSystem particle;

    private void Start()
    {
        particle = GameObject.Find("fire_another").GetComponent<ParticleSystem>();

        _bullet = GameObject.Find("gamemanager").GetComponent<fpscap>();
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-100, 110), Random.Range(-100, 110), Random.Range(-100, 110));
        transform.position = randomSpawnPosition;
        _gameover = GameObject.Find("gamemanager").GetComponent<GAMEOVER>();
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
            _gameover.score += 60;
        }
    }

}
