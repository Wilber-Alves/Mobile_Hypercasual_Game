using UnityEngine;

    public class PowerUpCoins : PowerUpBase
    {
        [Header("Coin Collector")]
        public float sizeAmount = 7;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        var manager = PlayerController.Instance.GetComponent<PowerUpManager>();

        if (manager != null)
        {
            manager.StartCoinCollector(sizeAmount, duration);
        }
    }
}
