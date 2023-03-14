using System;
using Game.Scripts.Savable;
using Game.Upgrades.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Upgrades.Scripts
{
    [DefaultExecutionOrder(-555)]
    public class UpgradeSource : MonoBehaviour
    {
        [field: Header("Save key = GameObject.name + Data.name")]
        [field: SerializeField]
        public UpgradeValues Values { get; private set; }

        public static Action OnAnyUpgrade;
        public Action OnUpgrade;

        public virtual bool HasNextLvl => Values.MaxLvl > CurrentLvl;

        private IntDataValueSavable _upgradeData;

        public int CurrentLvl => _upgradeData.Value;

        public void ResetData()
        {
            _upgradeData.Value = 0;
            _upgradeData.Save();
            OnUpgrade?.Invoke();
        }

        private void Awake()
        {
            Init(gameObject.name);
        }


        private void Init(string key)
        {
            _upgradeData = new IntDataValueSavable(name + key);
            OnUpgrade?.Invoke();
        }

        public bool LvlUp()
        {
            if (!HasNextLvl) return false;

            _upgradeData.Value++;
            _upgradeData.Save();
            OnUpgrade?.Invoke();
            OnAnyUpgrade?.Invoke();
            return true;
        }

        public bool AbleToUp =>
            HasNextLvl && MoneyHandler.Data.Value >= Values.NextLvlPrice(CurrentLvl);
    }
}