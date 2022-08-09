using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetHP : MonoBehaviour
{
    public float _maxHealth = 100f;
    public float _CurrentHealth = 100f;
    [SerializeField] private HealthBar _healthbar;
 
    private void Start()
    {
        _CurrentHealth = _maxHealth;

        _healthbar.UpdateHealthBar(_maxHealth, _CurrentHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("asteroida"))
        {
            _CurrentHealth -= 10;
            _healthbar.UpdateHealthBar(_maxHealth, _CurrentHealth);
        }
    }
}
