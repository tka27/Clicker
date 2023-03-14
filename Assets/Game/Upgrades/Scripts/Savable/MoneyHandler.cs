using System;

namespace Game.Upgrades.Scripts.Savable
{
    public static class MoneyHandler
    {
        public static event Action OnValueChanged;

        private static IntDataValueSavable _data = new("MoneyDataKey");
        public static IntDataValueSavable Data => _data;

        public static void AddMoney(int addedValue)
        {
            if (addedValue < 0)
                throw new ArgumentOutOfRangeException(null, "ArgumentOutOfRange_BadAddedValue");

            _data.Value += addedValue;
            OnValueChanged?.Invoke();
        }

        public static bool TrySubtractMoney(int subtractValue)
        {
            if (subtractValue > 0)
                throw new ArgumentOutOfRangeException(null, "ArgumentOutOfRange_BadSubtractedValue");

            if (_data.Value - subtractValue < 0) return false;


            _data.Value -= subtractValue;
            OnValueChanged?.Invoke();
            return true;
        }
    }
}