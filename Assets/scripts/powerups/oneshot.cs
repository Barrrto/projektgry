using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneshot : MonoBehaviour
{
    [SerializeField] private asteroida _asteroida;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("statek"))
        {
            OneShot();
        }
    }
    private void Update()
    {
        Destroy(gameObject, 10);
    }
    private void OneShot()
    {

    }
}
