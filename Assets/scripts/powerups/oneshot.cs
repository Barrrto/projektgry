using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneshot : MonoBehaviour
{
    [SerializeField] private asteroida _asteroida;
    [SerializeField] private asteroida_upgrade _asteroidaupgrade;
    [SerializeField] private fpscap _bulletcontroller;
    
    private void Start()
    {
        _bulletcontroller = GameObject.Find("gamemanager").GetComponent<fpscap>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("statek"))
        {
            _bulletcontroller.OneShot();
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Destroy(gameObject, 10);
    }
    
}
