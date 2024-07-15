using Sample;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Default
{
    public class Helper:MonoBehaviour
    {
        [SerializeField]
        private UpgradeConfig config;
        
        private PlayerStats _stats;

        private Upgrade _upgrade;

        private void Awake()
        {
            _upgrade = config.InstantiateUpgrade();
        }

        [Inject]
        public void Construct(PlayerStats stats)
        {
            _stats = stats;
        }

        [Button]
        public void AddStat(string statName, int value)
        {
            _stats.AddStat(statName,value);
        }

        [Button]
        public void LevelUp()
        {
            if(_upgrade.isMaxLevel) return;
            
            _upgrade.LevelUp();
        }
    }
}