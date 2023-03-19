using Game.Scripts.Ecs;
using Game.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.MonoBehaviours
{
    public class BusinessProvider : MonoBehaviour
    {
        [field: SerializeField] public BusinessData BusinessData { get; private set; }
        [field: SerializeField] public Image ProgressBar { get; private set; }

        private void Start()
        {
            if (BusinessData.Upgrade.CurrentLvl > 0) CreateEntity();
            else BusinessData.Upgrade.OnUpgradeEvent += CreateEntity;
        }

        private void OnDestroy()
        {
            BusinessData.Upgrade.OnUpgradeEvent -= CreateEntity;
        }

        private void CreateEntity()
        {
            BusinessData.Upgrade.OnUpgradeEvent -= CreateEntity;
            var entity = Startup.World.NewEntity();
            Startup.World.GetPool<Business>().Add(entity).Provider = this;
            Startup.World.GetPool<BusinessProgress>().Add(entity).ProgressTime = new($"{BusinessData.name}_progress");
        }
    }
}