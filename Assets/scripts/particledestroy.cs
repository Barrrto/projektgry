using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particledestroy : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1);
    }
}
