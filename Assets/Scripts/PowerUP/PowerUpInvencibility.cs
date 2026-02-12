using UnityEngine;

public class PowerUpInvencibility : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Invencibility!");
        PlayerController.Instance.SetInvencibility(true);
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetInvencibility(false);
        PlayerController.Instance.SetPowerUpText("");
    }
}




