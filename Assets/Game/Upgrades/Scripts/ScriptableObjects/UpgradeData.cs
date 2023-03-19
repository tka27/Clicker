using System;
using Game.Scripts.Savable;
using UnityEngine;

namespace Game.Upgrades.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class UpgradeData : ScriptableObject
    {
        public event Action OnUpgradeEvent;
        [SerializeField, Min(0)] private int _defaultPrice;

        private IntDataValueSavable _saveData;
        private IntDataValueSavable SaveData => _saveData ??= new(name);

        public int CurrentLvl => SaveData.Value;
        public bool AbleToUp => MoneyHandler.Data.Value >= NextLvlPrice;
        public int NextLvlPrice => _defaultPrice * (SaveData.Value + 1);

        public void LvlUp()
        {
            if (!MoneyHandler.TrySubtractMoney(NextLvlPrice)) return;
            SaveData.Value++;
            OnUpgradeEvent?.Invoke();
        }

        private void OnDisable()
        {
            _saveData?.Save();
        }
    }
}