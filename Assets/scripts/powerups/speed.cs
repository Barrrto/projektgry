using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    [SerializeField] private  playermovement _playermovement;
    [SerializeField] private ParticleSystem speedpart;
    private void Start()
    {
        Destroy(gameObject, 10);
        _playermovement = GameObject.Find("Playership").GetComponent<playermovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("statek"))
        {
            _playermovement.Speed();
            Instantiate(speedpart, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}
