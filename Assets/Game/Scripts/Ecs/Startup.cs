using Game.Scripts.Ecs.Systems;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Scripts.Ecs
{
    public class Startup : MonoBehaviour
    {
        public static EcsWorld World { get; private set; }

        //статический мир мне необходим для доступа вне ecs.
        //внутри ecs я его использую потому что у меня уже есть к нему доступ, иначе я бы его получал из систем или инжекта
        private IEcsSystems _systems;


        public void Start()
        {
            World = new EcsWorld();
            _systems = new EcsSystems(World);
            _systems
                .Add(new ProgressSystem())
                .Add(new ProgressViewSystem())
                .Add(new RewardSystem()) //
                .Init();
        }

        public void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }

            if (World != null)
            {
                World.Destroy();
                World = null;
            }
        }
    }
}