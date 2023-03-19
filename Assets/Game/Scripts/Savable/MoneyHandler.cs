using System;

namespace Game.Scripts.Savable
{
    public static class MoneyHandler
    {
        public static event Action OnValueChanged;

        public static FloatDataValueSavable Data { get; } = new("money_data_key");

        public static void AddMoney(float addedValue)
        {
            if (addedValue < 0)
                throw new ArgumentOutOfRangeException(null, "ArgumentOutOfRange_BadAddedValue");

            Data.Value += addedValue;
            Data.Save();
            OnValueChanged?.Invoke();
        }

        public static bool TrySubtractMoney(float subtractValue)
        {
            if (subtractValue < 0)
                throw new ArgumentOutOfRangeException(null, "ArgumentOutOfRange_BadSubtractedValue");

            if (Data.Value - subtractValue < 0) return false;


            Data.Value -= subtractValue;
            OnValueChanged?.Invoke();
            Data.Save();
            return true;
        }
    }
}