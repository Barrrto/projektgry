using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    [SerializeField] private  playermovement _playermovement;

    private void Start()
    {
         _playermovement = GameObject.Find("Playership").GetComponent<playermovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("statek"))
        {
            _playermovement.Speed();
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Destroy(gameObject, 10);
    }
    
}
