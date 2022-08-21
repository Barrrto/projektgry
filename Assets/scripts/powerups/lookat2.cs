using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat2 : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void Update()
    {
        transform.LookAt(target);
    }
    
}
