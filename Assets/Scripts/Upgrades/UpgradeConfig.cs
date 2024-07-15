using System;
using Default;
using UnityEngine;

namespace Sample
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        private const float _SPACE_HEIGHT = 10.0f;

        [SerializeField]
        public string id;
        
        [Range(2, 99)]
        [SerializeField]
        public int maxLevel = 2;

        [Space(_SPACE_HEIGHT)]
        [SerializeField]
        private PriceTable priceTable;

        public abstract Upgrade InstantiateUpgrade();

        private void OnValidate()
        {
            try
            {
                Validate();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        
        protected virtual void Validate()
        {
            priceTable.OnValidate(maxLevel);
        }
        
        
        public int GetPrice(int level)
        {
            return priceTable.GetPrice(level);
        }
    }
}