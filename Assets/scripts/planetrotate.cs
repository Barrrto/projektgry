using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetrotate : MonoBehaviour
{
    private int speed = 20;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
        transform.Rotate(Vector3.right * Time.deltaTime * speed);

    }
}
