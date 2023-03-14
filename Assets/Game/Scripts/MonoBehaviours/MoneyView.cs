using Game.Scripts.Savable;
using TMPro;
using UnityEngine;

namespace Game.Scripts.MonoBehaviours
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        private void Start()
        {
            MoneyHandler.OnValueChanged += UpdateText;
            UpdateText();
        }

        private void OnDestroy()
        {
            MoneyHandler.OnValueChanged -= UpdateText;
        }

        private void UpdateText()
        {
            _moneyText.text = $"{MoneyHandler.Data.Value}$";
        }
    }
}