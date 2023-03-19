using Leopotam.EcsLite;

namespace Game.Scripts.Ecs.Systems
{
    public class SaveSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var businessFilter = systems.GetWorld().Filter<Business>().Inc<BusinessProgress>().End();
            var businessPool = systems.GetWorld().GetPool<Business>();
            var progressPool = systems.GetWorld().GetPool<BusinessProgress>();

            foreach (var entity in businessFilter)
            {
                businessPool.Get(entity).Provider.BusinessData.Save();
                progressPool.Get(entity).ProgressTime.Save();
            }
        }
    }
}