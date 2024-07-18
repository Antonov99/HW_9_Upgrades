using Default;
using UnityEngine;

namespace Sample.Implementations
{
    [CreateAssetMenu(
        fileName = "SpeedUpgrade",
        menuName = "Sample/New SpeedUpgrade"
    )]
    public class SpeedUpgradeConfig:UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade(PlayerStats stats)
        {
            return new SpeedUpgrade(this, stats);
        }
    }
}