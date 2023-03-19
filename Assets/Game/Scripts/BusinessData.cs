using Game.Upgrades.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Scripts
{
    [CreateAssetMenu]
    public class BusinessData : ScriptableObject
    {
        [field: SerializeField, Min(0)] public float IncomeDelay { get; private set; }
        [field: SerializeField, Min(0)] public int BasePrice { get; private set; }
        [field: SerializeField, Min(0)] public int BaseIncome { get; private set; }
        [field: SerializeField] public UpgradeData Upgrade { get; private set; }

        public int CurrentIncome => Upgrade.CurrentLvl == 0 ? BaseIncome : BaseIncome * Upgrade.CurrentLvl;
    }
}