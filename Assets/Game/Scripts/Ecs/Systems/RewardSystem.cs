using Game.Scripts.Savable;
using Leopotam.EcsLite;

namespace Game.Scripts.Ecs.Systems
{
    public class RewardSystem : IEcsRunSystem
    {
        private readonly EcsFilter _businessFilter = Startup.World.Filter<BusinessProgress>().Inc<Business>().End();
        private readonly EcsPool<Business> _businessPool = Startup.World.GetPool<Business>();
        private readonly EcsPool<BusinessProgress> _progressPool = Startup.World.GetPool<BusinessProgress>();

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _businessFilter)
            {
                var progress = _progressPool.Get(entity).ProgressTime;
                var business = _businessPool.Get(entity);
                var delay = business.Provider.BusinessData.IncomeDelay;

                if (progress.Value < delay) continue;
                MoneyHandler.AddMoney(business.Provider.BusinessData.CurrentIncome);
                progress.Value -= delay;
            }
        }
    }
}