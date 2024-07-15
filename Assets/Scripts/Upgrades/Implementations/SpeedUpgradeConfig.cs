using UnityEngine;

namespace Sample.Implementations
{
    [CreateAssetMenu(
        fileName = "SpeedUpgrade",
        menuName = "Sample/New SpeedUpgrade"
    )]
    public class SpeedUpgradeConfig:UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new SpeedUpgrade(this);
        }
    }
}