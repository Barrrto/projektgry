using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    [SerializeField] private asteroida _asteroida1;
    [SerializeField] private asteroida_upgrade _asteroida2;
   
    private void Update()
    {
         _asteroida1 = GameObject.FindWithTag("asteroida").GetComponent<asteroida>();
        _asteroida2 = GameObject.FindWithTag("asteroida2").GetComponent<asteroida_upgrade>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("statek"))
        {
            
            _asteroida1.freeze2();
            _asteroida1.colorchange();

            _asteroida2.freeze2();
            _asteroida2.colorchange();
            Destroy(gameObject);
        }
    }

    
}
