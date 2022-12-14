using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroida : MonoBehaviour
{
    private int life = 3;
    public Transform target;
    public float asteroidspeed = 0.2f;

    [SerializeField] private ParticleSystem destroy;
   
    [SerializeField] private fpscap _bullet2;
    [SerializeField] private GAMEOVER _gameover;
    [SerializeField] AudioSource asteroid_destroy;
    [SerializeField] AudioSource earth_sound;
    private void Start()
    {   
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-100, 110), Random.Range(-100, 110), Random.Range(-100, 110));
        transform.position = randomSpawnPosition;
        _bullet2 = GameObject.Find("gamemanager").GetComponent<fpscap>();
        _gameover = GameObject.Find("gamemanager").GetComponent<GAMEOVER>();
        asteroid_destroy = GameObject.Find("asteroid_destroy").GetComponent<AudioSource>();
        earth_sound = GameObject.Find("earth_sound").GetComponent<AudioSource>();
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
            life = life - _bullet2.bulletdmg;
            
        }
        if (other.CompareTag("planeta"))
        {
            Destroy(gameObject);
            Instantiate(destroy, transform.position, Quaternion.identity);
            earth_sound.Play();
        }
        if (life == 0)
        {
            Destroy(gameObject);
            _gameover.score += 40;
            Instantiate(destroy, transform.position, Quaternion.identity);
            asteroid_destroy.Play();
        }
    }
}
