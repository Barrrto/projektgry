using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform gunpoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            var bullet = Instantiate(bulletPrefab, gunpoint.position, gunpoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = gunpoint.forward * bulletSpeed;
        }
    }
}
