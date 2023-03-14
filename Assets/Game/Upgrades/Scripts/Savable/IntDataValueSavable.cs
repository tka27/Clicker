using Common;
using UnityEngine;

namespace Game.Upgrades.Scripts.Savable
{
    public class IntDataValueSavable : DataValueSavable<int>
    {
        private const string IntDataValue = "int_data_value";

        public IntDataValueSavable(string saveKey) : base(saveKey)
        {
        }

        protected override void Load()
        {
            base.Load();
            Value = PlayerPrefs.GetInt(IntDataValue + SaveKey, 0);
        }

        public override void Save()
        {
            base.Save();
            PlayerPrefs.SetInt(IntDataValue + SaveKey, Value);
        }

        public override bool HasSaving()
        {
            return PlayerPrefs.HasKey(IntDataValue + SaveKey);
        }
    }
}