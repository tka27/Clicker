using UnityEngine;

namespace Game.Upgrades.Scripts.ScriptableObjects
{
    [CreateAssetMenu]
    public class UpgradeValues : ScriptableObject
    {
        [SerializeField] private AnimationCurve _prices;

        public float MaxLvl => _prices.keys[_prices.length - 1].time + 1;


        public int NextLvlPrice(int currentLvl) => (int)_prices.Evaluate(currentLvl);
    }
}