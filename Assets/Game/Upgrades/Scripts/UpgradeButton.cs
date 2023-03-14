using Game.Scripts.Savable;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Upgrades.Scripts
{
    public sealed class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private UpgradeSource _source;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Button _button;

        [Header("Levels Display"), SerializeField]
        private TextMeshProUGUI _lvlText;

        public Button Button => _button;

        public void DisableBtn()
        {
            _button.interactable = false;
        }

        private void UpdateDisplay()
        {
            _priceText.text = !_source.HasNextLvl ? "MAX" : _source.Values.NextLvlPrice(_source.CurrentLvl).ToString();
            if (_lvlText) _lvlText.text = $"LVL {_source.CurrentLvl + 1}";
        }


        private void SwitchBtn()
        {
            if (!enabled) return;
            _button.interactable = _source.AbleToUp;

            UpdateDisplay();
        }

        private void LvlUp()
        {
            if (!MoneyHandler.TrySubtractMoney(_source.Values.NextLvlPrice(_source.CurrentLvl))) return;
            _source.LvlUp();
        }


        private void OnEnable()
        {
            MoneyHandler.OnValueChanged += SwitchBtn;
            _button.onClick.AddListener(LvlUp);
            _source.OnUpgrade += UpdateDisplay;
            _source.OnUpgrade += SwitchBtn;
            SwitchBtn();
            UpdateDisplay();
        }

        private void OnDisable()
        {
            MoneyHandler.OnValueChanged -= SwitchBtn;
            _button.onClick.RemoveListener(LvlUp);
            _source.OnUpgrade -= UpdateDisplay;
            _source.OnUpgrade -= SwitchBtn;
        }
    }
}