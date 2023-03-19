using Game.Scripts.Savable;
using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu]
    public class ImprovementData : ScriptableObject
    {
        private BoolDataValueSavable _saveData;
        [field: SerializeField, Min(0)] public int Price { get; private set; }
        [field: SerializeField, Min(0)] public float IncomeMultiplier { get; private set; }
        public bool IsBought => SaveData.Value;

        public void BuyImprovement()
        {
            if (!MoneyHandler.TrySubtractMoney(Price)) return;
            SaveData.Value = true;
        }

        private BoolDataValueSavable SaveData => _saveData ??= new(name);

        private void OnDestroy()
        {
            _saveData.Save();
        }
    }
}