using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeight : PowerUpBase
{
    [Header("Power Up Height")]
    public float amountHeight = 2;
    public float animationDuration = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;
    protected override void StartPowerUp()
    {
        
        var manager = PlayerController.Instance.GetComponent<PowerUpManager>();

        if (manager != null)
        {
            manager.StartHeight(amountHeight, duration, animationDuration, ease);
        }
    }
}

