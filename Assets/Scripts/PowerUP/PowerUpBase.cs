using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("Power Up Settings")]
    public float duration = 5f;

    protected override void OnCollect()
    {
   
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
       
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");
   
        Destroy(gameObject);
    }
}