using Default;

namespace Sample.Implementations
{
    public class SpeedUpgrade : Upgrade
    {
        private readonly SpeedUpgradeConfig _config;
        private readonly PlayerStats _stats;

        public SpeedUpgrade(SpeedUpgradeConfig config, PlayerStats stats) : base(config)
        {
            _config = config;
            _stats = stats;
        }

        protected override void LevelUp(int lvl)
        {
            var speed = _stats.GetStat("speed") + 1;
            _stats.SetStat("speed", speed);
        }
    }
}