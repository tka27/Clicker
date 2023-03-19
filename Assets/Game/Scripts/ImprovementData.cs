using Game.Scripts.Savable;
using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu]
    public class ImprovementData : ScriptableObject
    {
        public event System.Action OnBuyEvent;
        private BoolDataValueSavable _saveData;
        [field: SerializeField, Min(0)] public int Price { get; private set; }
        [field: SerializeField, Min(0)] public float IncomePercentage { get; private set; }
        public bool IsBought => SaveData.Value;
        public float IncomeMultiplier => !IsBought ? 0 : IncomePercentage;

        public void BuyImprovement()
        {
            if (!MoneyHandler.TrySubtractMoney(Price)) return;
            SaveData.Value = true;
            OnBuyEvent?.Invoke();
        }

        private BoolDataValueSavable SaveData => _saveData ??= new(name);

        private void OnDisable()
        {
            _saveData?.Save();
        }
    }
}