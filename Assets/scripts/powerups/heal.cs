using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class heal : MonoBehaviour
{
    [SerializeField] private PlanetHP _planethp;
    [SerializeField] private ParticleSystem healpart;
    [SerializeField] private GAMEOVER _gameover;
    private void Start()
    {
        _planethp = GameObject.Find("planet_controller").GetComponent<PlanetHP>();
        Destroy(gameObject, 10);
        _gameover = GameObject.Find("gamemanager").GetComponent<GAMEOVER>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("statek"))
        {
            _planethp.Heal();
            Instantiate(healpart, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _gameover.score += 15;
        }
    }
}
