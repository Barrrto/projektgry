using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public static camerafollow instance;

    public Transform targetPoint;

    public float moveSpeed = 10f, rotateSpeed = 10f;

    private void Awake()
    {
        instance = this;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetPoint.rotation, rotateSpeed * Time.deltaTime);

    }
}
