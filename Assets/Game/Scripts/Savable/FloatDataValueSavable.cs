using UnityEngine;

namespace Game.Scripts.Savable
{
    public class FloatDataValueSavable : DataValueSavable<float>
    {
        private const string FloatDataValue = "float_data_value";

        public FloatDataValueSavable(string saveKey) : base(saveKey)
        {
        }

        protected override void Load()
        {
            base.Load();
            Value = PlayerPrefs.GetFloat(FloatDataValue + SaveKey, 0f);
        }

        public override void Save()
        {
            base.Save();
            PlayerPrefs.SetFloat(FloatDataValue + SaveKey, Value);
        }

        public override bool HasSaving()
        {
            return PlayerPrefs.HasKey(FloatDataValue + SaveKey);
        }
    }
}