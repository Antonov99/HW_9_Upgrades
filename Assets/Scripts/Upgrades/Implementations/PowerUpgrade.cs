using Default;
using UnityEngine;
using Zenject;

namespace Sample.Implementations
{
    public class PowerUpgrade:Upgrade
    {
        private readonly PowerUpgradeConfig _config;
        private PlayerStats _stats;

        public PowerUpgrade(PowerUpgradeConfig config) : base(config)
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
            Debug.Log("Не инжектится в 18 строке");
            //var power = _stats.GetStat("power") + 1;
            //_stats.SetStat("power", power);
        }
    }
}