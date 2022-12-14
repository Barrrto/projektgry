using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform gunpoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 15f;
    public float _maxReload = 100f;
    public float _currentReload = 0f;
    [SerializeField] private ReloadBar _ReloadBar;
    [SerializeField] private ParticleSystem shoot_part;
    [SerializeField] private ParticleSystem shoot_part2;
    [SerializeField] private AudioSource shoot_audio;
    private bool canshoot;
    private float nextTimeToFire = 0f;

    public Transform target;

    private void Start()
    {
        _currentReload = 0;
        _ReloadBar.UpdateReloadBar(_maxReload, _currentReload);
    }
    private void shoot()
    {
        if (canshoot == true)
        {
            if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                var bullet = Instantiate(bulletPrefab, gunpoint.position, gunpoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = target.forward * bulletSpeed;

                shoot_part.Play();
                shoot_part2.Play();

                shoot_audio.Play();
                _currentReload += 20;
                _ReloadBar.UpdateReloadBar(_maxReload, _currentReload);
            }
        }
        if (canshoot == false)
        {
            InvokeRepeating("Decap", 5, 1f);
            _ReloadBar.UpdateReloadBar(_maxReload, _currentReload);

        }
        if (Input.GetMouseButtonUp(0))
        {
            InvokeRepeating("Decap", 2f, 2.5f);
            if (_currentReload >= 100)
            {
                CancelInvoke("Decap");
                _ReloadBar.UpdateReloadBar(_maxReload, _currentReload);
            }
            InvokeRepeating("Decap", 2.5f, 1f);
            
        }
    }
    private void Update()
    {
            
            if(_currentReload < 100)
            {
                canshoot = true;
                shoot();

        }
            if(_currentReload >= 100 )
            {
                canshoot = false;
                shoot();
            } 
    }
    private void Decap()
    {
        _ReloadBar.UpdateReloadBar(_maxReload, _currentReload);
        canshoot = false;
        _currentReload -= 10f;
        if(_currentReload == -10)
        {
            CancelInvoke("Decap");
        }
    }
}
