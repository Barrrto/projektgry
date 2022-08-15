using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class heal : MonoBehaviour
{
    [SerializeField] private PlanetHP _planethp;


    private void Start()
    {
        _planethp = GameObject.Find("Earth_final").GetComponent<PlanetHP>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("statek"))
        {
            _planethp.Heal();
            Destroy(gameObject);
           
        }
    }
    private void Update()
    {
        Destroy(gameObject, 20);
    }
}
