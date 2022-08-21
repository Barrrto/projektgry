using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneshot : MonoBehaviour
{
    [SerializeField] private asteroida _asteroida;
    [SerializeField] private asteroida_upgrade _asteroidaupgrade;
    [SerializeField] private fpscap _bulletcontroller;
    [SerializeField] private ParticleSystem oneshotpart;

    private void Start()
    {
        _bulletcontroller = GameObject.Find("gamemanager").GetComponent<fpscap>();
        Destroy(gameObject, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("statek"))
        {
            _bulletcontroller.OneShot();
            Instantiate(oneshotpart, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}
