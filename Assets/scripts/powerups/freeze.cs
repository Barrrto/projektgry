using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    [SerializeField] private asteroida _asteroida;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("statek"))
        {
            Freeze();
        }
    }

    private void Update()
    {
        Destroy(gameObject, 10);
    }
    private void Freeze()
    {

    }

}
