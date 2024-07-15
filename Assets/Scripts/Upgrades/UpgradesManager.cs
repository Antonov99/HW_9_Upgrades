using System;
using System.Collections.Generic;
using System.Linq;
using Default;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Sample
{
    [Serializable]
    public sealed class UpgradesManager
    {
        public event Action<Upgrade> OnLevelUp;
        
        [ReadOnly, ShowInInspector]
        private Dictionary<string, Upgrade> _upgrades = new();

        private MoneyStorage _moneyStorage;

        [Inject]
        public void Construct(MoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
            Debug.Log("Inject");
        }

        public void Setup(Upgrade[] upgrades)
        {
            _upgrades = new Dictionary<string, Upgrade>();
            for (int i = 0, count = upgrades.Length; i < count; i++)
            {
                var upgrade = upgrades[i];
                _upgrades[upgrade.id] = upgrade;
            }
        }

        public Upgrade GetUpgrade(string id)
        {
            return _upgrades[id];
        }

        public Upgrade[] GetAllUpgrades()
        {
            return _upgrades.Values.ToArray();
        }

        public bool CanLevelUp(Upgrade upgrade)
        {
            if (upgrade.isMaxLevel)
            {
                return false;
            }

            var price = upgrade.nextPrice;
            return _moneyStorage.CanSpendMoney(price);
        }

        public void LevelUp(Upgrade upgrade)
        {
            if (!CanLevelUp(upgrade))
            {
                throw new Exception($"Can not level up {upgrade.id}");
            }

            var price = upgrade.nextPrice;
            _moneyStorage.SpendMoney(price);

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