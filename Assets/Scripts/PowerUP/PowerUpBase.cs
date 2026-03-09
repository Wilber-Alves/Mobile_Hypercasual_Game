using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
   public float duration = 5f;

   protected override void OnCollect()
   {
      StartPowerUp();
      Destroy(gameObject);
   }

    protected virtual void StartPowerUp()
    {

    }
}