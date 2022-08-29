using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    [SerializeField] private  playermovement _playermovement;
    [SerializeField] private ParticleSystem speedpart;
    [SerializeField] private GAMEOVER _gameover;
    private void Start()
    {
        Destroy(gameObject, 10);
        _playermovement = GameObject.Find("Playership").GetComponent<playermovement>();
        _gameover = GameObject.Find("gamemanager").GetComponent<GAMEOVER>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("statek"))
        {
            _playermovement.Speed();
            Instantiate(speedpart, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _gameover.score += 15;
        }
    }
    
}
