using UnityEngine;

namespace Sample.Implementations
{
    [CreateAssetMenu(
        fileName = "PowerUpgrade",
        menuName = "Sample/New PowerUpgrade"
    )]
    public class PowerUpgradeConfig:UpgradeConfig
    {
        public override Upgrade InstantiateUpgrade()
        {
            return new PowerUpgrade(this);
        }
    }
}