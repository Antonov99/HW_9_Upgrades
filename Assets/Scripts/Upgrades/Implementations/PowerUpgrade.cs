using Default;

namespace Sample.Implementations
{
    public class PowerUpgrade:Upgrade
    {
        private readonly PowerUpgradeConfig _config;
        private readonly PlayerStats _stats;

        public PowerUpgrade(PowerUpgradeConfig config, PlayerStats stats) : base(config)
        {
            _config = config;
            _stats = stats;
        }

        protected override void LevelUp(int lvl)
        {
            var power = _stats.GetStat("power") + 1;
            _stats.SetStat("power", power);
        }
    }
}