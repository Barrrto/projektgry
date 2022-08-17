using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpscap : MonoBehaviour
{
    [SerializeField] int frameRate = 60;
    public int bulletdmg = 1;
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }

    IEnumerator onetap()
    {
        yield return new WaitForSeconds(15f);
        bulletdmg = 1;
    }

    public void OneShot()
    {
        bulletdmg = 3;
        StartCoroutine(onetap());
    }
}
