using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Ecs.Systems
{
    public class ProgressViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter _businessFilter = Startup.World.Filter<BusinessProgress>().Inc<Business>().End();
        private readonly EcsPool<Business> _businessPool = Startup.World.GetPool<Business>();
        private readonly EcsPool<BusinessProgress> _progressPool = Startup.World.GetPool<BusinessProgress>();

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _businessFilter)
            {
                var provider = _businessPool.Get(entity).Provider;
                var lerpValue = _progressPool.Get(entity).ProgressTime.Value / provider.BusinessData.IncomeDelay;
                provider.ProgressBar.fillAmount = lerpValue;
            }
        }
    }
}