using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountToSpeed;
    protected override void StartPowerUp()
    {
        var manager = PlayerController.Instance.GetComponent<PowerUpManager>();
        if (manager != null)
        {
            manager.StartSpeed(amountToSpeed, duration);
        }
    }
}
