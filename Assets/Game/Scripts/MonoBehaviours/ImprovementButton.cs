using Game.Scripts.Savable;
using Game.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.MonoBehaviours
{
    public class ImprovementButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _income;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private ImprovementData _data;
        [SerializeField] private Button _button;


        private void Awake()
        {
            SwitchButton();
            if (_data.IsBought) return;
            MoneyHandler.OnValueChanged += SwitchButton;
            _button.onClick.AddListener(_data.BuyImprovement);
            _button.onClick.AddListener(SwitchButton);
        }

        private void OnDestroy()
        {
            MoneyHandler.OnValueChanged -= SwitchButton;
        }

        private void SwitchButton()
        {
            if (_data.IsBought)
            {
                _button.interactable = false;
                _price.text = "Is bought";
                MoneyHandler.OnValueChanged -= SwitchButton;
                return;
            }

            _button.interactable = MoneyHandler.Data.Value >= _data.Price;
        }

        private void OnValidate()
        {
            _name.text = _data.name;
            _income.text = $"Income: +{_data.IncomePercentage:P0}";
            _price.text = $"Price: {_data.Price}$";
        }
    }
}