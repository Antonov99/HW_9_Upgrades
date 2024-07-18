using Default;
using UnityEngine;

namespace Sample.Implementations
{
    [CreateAssetMenu(
        fileName = "PowerUpgrade",
        menuName = "Sample/New PowerUpgrade"
    )]
    public class PowerUpgradeConfig:UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade(PlayerStats stats)
        {
            return new PowerUpgrade(this, stats);
        }
    }
}