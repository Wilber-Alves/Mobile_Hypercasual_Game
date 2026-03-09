using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PowerUpInvencibility : PowerUpBase
{
    protected override void StartPowerUp()
    {
        
        var manager = PlayerController.Instance.GetComponent<PowerUpManager>();

        if (manager != null)
        {
           
            manager.StartInvincibility(duration);
        }
    }
}





