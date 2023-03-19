using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Ecs.Systems
{
    public class ProgressSystem : IEcsRunSystem
    {
        private readonly EcsFilter _businessFilter = Startup.World.Filter<BusinessProgress>().End();

        private readonly EcsPool<BusinessProgress> _progressPool = Startup.World.GetPool<BusinessProgress>();

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _businessFilter)
            {
                _progressPool.Get(entity).ProgressTime.Value += Time.deltaTime;
            }
        }
    }
}