using System.Text;
using TMPro;
using UnityEngine;

namespace Game.Scripts.MonoBehaviours
{
    public class BusinessTabView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _lvl;
        [SerializeField] private TextMeshProUGUI _income;
        [SerializeField] private TextMeshProUGUI _price;

        [field: SerializeField] public BusinessData BusinessData { get; private set; }

        private void Start()
        {
            UpdateText();
            BusinessData.Upgrade.OnUpgradeEvent += UpdateText;
        }

        private void OnDestroy()
        {
            BusinessData.Upgrade.OnUpgradeEvent -= UpdateText;
        }

        private void UpdateText()
        {
            StringBuilder builder = new();
            LevelTextUpdate(builder);
            IncomeTextUpdate(builder);
            PriceTextUpdate(builder);
        }

        private void LevelTextUpdate(in StringBuilder builder)
        {
            builder.Append("LVL");
            builder.Append("\n");
            builder.Append(BusinessData.Upgrade.CurrentLvl);
            _lvl.text = builder.ToString();
            builder.Clear();
        }

        private void IncomeTextUpdate(in StringBuilder builder)
        {
            builder.Append("Income");
            builder.Append("\n");
            builder.Append(BusinessData.CurrentIncome);
            builder.Append("$");
            _income.text = builder.ToString();
            builder.Clear();
        }

        private void PriceTextUpdate(in StringBuilder builder)
        {
            builder.Append("LEVEL UP");
            builder.Append("\n");
            builder.Append("Price: ");
            builder.Append(BusinessData.Upgrade.NextLvlPrice);
            builder.Append("$");
            _price.text = builder.ToString();
            builder.Clear();
        }
    }
}