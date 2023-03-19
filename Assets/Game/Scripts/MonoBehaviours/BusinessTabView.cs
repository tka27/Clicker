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

        private readonly StringBuilder _builder = new();

        private void Start()
        {
            UpdateText();
            BusinessData.Upgrade.OnUpgradeEvent += UpdateText;

            foreach (var improvement in BusinessData.Improvements)
            {
                if (improvement.IsBought) continue;
                improvement.OnBuyEvent += IncomeTextUpdate;
            }
        }

        private void OnDestroy()
        {
            BusinessData.Upgrade.OnUpgradeEvent -= UpdateText;
            foreach (var improvement in BusinessData.Improvements)
            {
                improvement.OnBuyEvent -= IncomeTextUpdate;
            }
        }

        private void UpdateText()
        {
            LevelTextUpdate();
            IncomeTextUpdate();
            PriceTextUpdate();
        }

        private void LevelTextUpdate()
        {
            _builder.Append("LVL");
            _builder.Append("\n");
            _builder.Append(BusinessData.Upgrade.CurrentLvl);
            _lvl.text = _builder.ToString();
            _builder.Clear();
        }

        private void IncomeTextUpdate()
        {
            _builder.Append("Income");
            _builder.Append("\n");
            _builder.Append(BusinessData.CurrentIncome);
            _builder.Append("$");
            _income.text = _builder.ToString();
            _builder.Clear();
        }

        private void PriceTextUpdate()
        {
            _builder.Append("LEVEL UP");
            _builder.Append("\n");
            _builder.Append("Price: ");
            _builder.Append(BusinessData.Upgrade.NextLvlPrice);
            _builder.Append("$");
            _price.text = _builder.ToString();
            _builder.Clear();
        }
    }
}