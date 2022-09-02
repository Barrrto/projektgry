using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    [SerializeField] private  playermovement _playermovement;
    [SerializeField] private ParticleSystem speedpart;
    [SerializeField] private GAMEOVER _gameover;
    [SerializeField] private AudioSource pickup;
    [SerializeField] private AudioSource boost_sound;
    private void Start()
    {
        Destroy(gameObject, 10);
        _playermovement = GameObject.Find("Playership").GetComponent<playermovement>();
        _gameover = GameObject.Find("gamemanager").GetComponent<GAMEOVER>();
        pickup = pickup = GameObject.Find("speed_sound").GetComponent<AudioSource>();
        boost_sound = GameObject.Find("boost_sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("statek"))
        {
            _playermovement.Speed();
            pickup.Play();
            boost_sound.Play();
            Instantiate(speedpart, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _gameover.score += 15;
        }
    }
    
}
