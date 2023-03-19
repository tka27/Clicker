using System;
using Game.Scripts.Savable;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class UpgradeData : SavableScriptableObject
    {
        public event Action OnUpgradeEvent;
        [SerializeField, Min(0)] private int _minimumLevel;

        [SerializeField, Min(0)] private int _defaultPrice;

        private IntDataValueSavable _saveData;

        private IntDataValueSavable SaveData
        {
            get
            {
                if (_saveData != null) return _saveData;

                _saveData = new(name);
                if (_saveData.Value < _minimumLevel) _saveData.Value = _minimumLevel;

                return _saveData;
            }
        }

        public int CurrentLvl => SaveData.Value;
        public bool AbleToUp => MoneyHandler.Data.Value >= NextLvlPrice;
        public int NextLvlPrice => _defaultPrice * (SaveData.Value + 1);

        public void LvlUp()
        {
            if (!MoneyHandler.TrySubtractMoney(NextLvlPrice)) return;
            SaveData.Value++;
            OnUpgradeEvent?.Invoke();
        }

        public override void Save()
        {
            SaveData.Save();
        }
    }
}