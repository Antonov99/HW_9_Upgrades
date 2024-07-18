using System;
using System.Collections.Generic;
using System.Linq;
using Default;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Sample
{
    public sealed class UpgradesManager : MonoBehaviour
    {
        public event Action<Upgrade> OnLevelUp;

        [ReadOnly, ShowInInspector]
        private Dictionary<string, Upgrade> _upgrades = new();

        [SerializeField]
        private MoneyStorage moneyStorage;

        [SerializeField]
        private UpgradeCatalog configs;

        private PlayerStats _stats;

        private void Awake()
        {
            var upgradeConfigs = configs.GetAllUpgrades();
            var upgrades = new Upgrade[upgradeConfigs.Length];
            for (int i = 0; i < upgrades.Length; i++)
            {
                upgrades[i]=upgradeConfigs[i].InstantiateUpgrade(_stats);
            }
            Setup(upgrades);
        }

        [Inject]
        public void Construct(MoneyStorage moneyStore, PlayerStats playerStats)
        {
            moneyStorage = moneyStore;
            _stats = playerStats;
        }

        [Button]
        public void AddStat(string statName, int value)
        {
            _stats.AddStat(statName, value);
        }

        private void Setup(Upgrade[] upgrades)
        {
            _upgrades = new Dictionary<string, Upgrade>();
            for (int i = 0, count = upgrades.Length; i < count; i++)
            {
                var upgrade = upgrades[i];
                _upgrades[upgrade.id] = upgrade;
            }
        }

        private Upgrade GetUpgrade(string id)
        {
            return _upgrades[id];
        }

        public Upgrade[] GetAllUpgrades()
        {
            return _upgrades.Values.ToArray();
        }

        private bool CanLevelUp(Upgrade upgrade)
        {
            if (upgrade.isMaxLevel)
            {
                return false;
            }

            var dependencies = upgrade.dependencies;
            foreach (var dependency in dependencies)
            {
                if (GetUpgrade(dependency).level <= upgrade.level)
                    return false;
            }

            var price = upgrade.nextPrice;
            return moneyStorage.CanSpendMoney(price);
        }

        private void LevelUp(Upgrade upgrade)
        {
            if (!CanLevelUp(upgrade))
            {
                throw new Exception($"Can not level up {upgrade.id}");
            }

            var price = upgrade.nextPrice;
            moneyStorage.SpendMoney(price);

            upgrade.LevelUp();
            OnLevelUp?.Invoke(upgrade);
        }

        [Title("Methods")]
        [Button]
        public bool CanLevelUp(string id)
        {
            var upgrade = _upgrades[id];
            return CanLevelUp(upgrade);
        }

        [Button]
        public void LevelUp(string id)
        {
            var upgrade = _upgrades[id];
            LevelUp(upgrade);
        }
    }
}