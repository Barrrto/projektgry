using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReloadBar : MonoBehaviour
{
    [SerializeField] private Image ReloadBarSprite;

    public void UpdateReloadBar(float maxReload, float currentReload)
    {
        ReloadBarSprite.fillAmount = currentReload / maxReload;
    }
}
