using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpscap : MonoBehaviour
{
    [SerializeField] int frameRate = 60;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }
}
