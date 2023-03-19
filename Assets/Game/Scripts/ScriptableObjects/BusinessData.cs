using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class BusinessData : SavableScriptableObject
    {
        [field: SerializeField, Min(0)] public float IncomeDelay { get; private set; }
        [field: SerializeField, Min(0)] public int BaseIncome { get; private set; }
        [field: SerializeField] public UpgradeData Upgrade { get; private set; }
        [field: SerializeField] public ImprovementData[] Improvements;

        public float CurrentIncome => (Upgrade.CurrentLvl == 0 ? BaseIncome : BaseIncome * Upgrade.CurrentLvl) *
                                      ImprovementsMultiplier();

        public override void Save()
        {
            for (int i = 0; i < Improvements.Length; i++)
            {
                Improvements[i].Save();
            }

            Upgrade.Save();
        }

        private float ImprovementsMultiplier()
        {
            float result = 1;
            for (int i = 0; i < Improvements.Length; i++)
            {
                result += Improvements[i].IncomeMultiplier;
            }

            return result;
        }
    }
}