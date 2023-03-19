using Game.Scripts.Savable;
using Game.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.MonoBehaviours
{
    public sealed class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private UpgradeData _data;
        [SerializeField] private Button _button;


        private void SwitchBtn()
        {
            if (!enabled) return;
            _button.interactable = _data.AbleToUp;
        }

        private void OnEnable()
        {
            MoneyHandler.OnValueChanged += SwitchBtn;
            _button.onClick.AddListener(_data.LvlUp);
            _data.OnUpgradeEvent += SwitchBtn;
            SwitchBtn();
        }

        private void OnDisable()
        {
            MoneyHandler.OnValueChanged -= SwitchBtn;
            _button.onClick.RemoveListener(_data.LvlUp);
            _data.OnUpgradeEvent -= SwitchBtn;
        }
    }
}