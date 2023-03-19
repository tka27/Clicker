using Game.Scripts.Savable;
using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class ImprovementData : SavableScriptableObject
    {
        public event System.Action OnBuyEvent;
        private BoolDataValueSavable _saveData;
        [field: SerializeField, Min(0)] public int Price { get; private set; }
        [field: SerializeField, Min(0)] public float IncomePercentage { get; private set; }
        public bool IsBought => SaveData.Value;
        public float IncomeMultiplier => !IsBought ? 0 : IncomePercentage;
        private BoolDataValueSavable SaveData => _saveData ??= new(name);

        public void BuyImprovement()
        {
            if (!MoneyHandler.TrySubtractMoney(Price)) return;
            SaveData.Value = true;
            OnBuyEvent?.Invoke();
        }

        public override void Save()
        {
            SaveData.Save();
        }
    }
}