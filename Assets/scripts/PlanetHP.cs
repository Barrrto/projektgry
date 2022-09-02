using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetHP : MonoBehaviour
{
    public float _maxHealth = 100f;
    public float _CurrentHealth = 100f;
    [SerializeField] private HealthBar _healthbar;
    [SerializeField] private PlanetHP _planethp;
    [SerializeField] private asteroidgenerator _asteroidgenerator;
    [SerializeField] private asteroida _asteroida;

    [SerializeField] private GameObject st;
    [SerializeField] private GameObject nd;
    [SerializeField] private GameObject rd;

    [SerializeField] private GAMEOVER _gameover;

    [SerializeField] private GameObject game;
    [SerializeField] private GameObject gameover;
    [SerializeField] private AudioSource end_sound;
    private void Start()
    {
        _CurrentHealth = _maxHealth;
        _healthbar.UpdateHealthBar(_maxHealth, _CurrentHealth);
        _gameover = GameObject.Find("gamemanager").GetComponent<GAMEOVER>(); ;
        _planethp = GameObject.FindWithTag("planeta").GetComponent<PlanetHP>();
        _asteroidgenerator = GameObject.FindWithTag("GameController").GetComponent<asteroidgenerator>();
        end_sound = GameObject.Find("BOOM").GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("asteroida"))
        {
            _CurrentHealth -= 10;
            _healthbar.UpdateHealthBar(_maxHealth, _CurrentHealth);
        }
        if (other.CompareTag("asteroida2"))
        {
            _CurrentHealth -= 20;
            _healthbar.UpdateHealthBar(_maxHealth, _CurrentHealth);
        }
        if(other.CompareTag("statek"))
        {
            game.SetActive(false);
            gameover.SetActive(true);
            Cursor.visible = true;
            _gameover.ScoreUpdate();
            end_sound.Play();
        }
    }
    private void Update()
    {
        _asteroida = GameObject.FindWithTag("asteroida").GetComponent<asteroida>();
        PlanetState();

        if (_CurrentHealth <= 0)
        {
            game.SetActive(false);
            gameover.SetActive(true);
            Cursor.visible = true;
            end_sound.Play();
        }
    }
    private void PlanetState()
    {
        if (_CurrentHealth <= 80 && _CurrentHealth > 40)
        {
            _asteroida.asteroidspeed = 0.3f;
            _asteroidgenerator.spawnDelay = 5.5f;
            
            second();
        }
        if (_CurrentHealth <= 40 && _CurrentHealth > 0)
        {
            _asteroida.asteroidspeed = 0.4f;
            _asteroidgenerator.spawnDelay = 5f;
            
            third();
        }
        
    }
    public void Heal()
    {
        _CurrentHealth += 20;
        _healthbar.UpdateHealthBar(_maxHealth, _CurrentHealth);        
    }

    public void second()
    {
        nd.SetActive(true);
        st.SetActive(false);
    }

    public void third()
    {
        nd.SetActive(false);
        rd.SetActive(true);
    }
}
