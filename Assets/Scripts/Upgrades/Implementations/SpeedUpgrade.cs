using Default;
using UnityEngine;
using Zenject;

namespace Sample.Implementations
{
    public class SpeedUpgrade:Upgrade
    {
        private readonly SpeedUpgradeConfig _config;
        private PlayerStats _stats;
        
        public SpeedUpgrade(SpeedUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        [Inject]
        public void Construct(PlayerStats stats)
        {
            _stats = stats;
            Debug.Log("Inject");
        }

        protected override void LevelUp(int lvl)
        {
            var speed = _config.GetPrice(lvl);
            _stats.SetStat("speed", speed);
        }
    }
}