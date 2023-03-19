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
        private IEcsSystems _saveSystems;

        private void Awake()
        {
            World = new EcsWorld();
            _systems = new EcsSystems(World);
            _systems
                .Add(new ProgressSystem())
                .Add(new ProgressViewSystem())
                .Add(new RewardSystem())
                .Init();

            _saveSystems = new EcsSystems(World);
            _saveSystems
                .Add(new SaveSystem())
                .Init();
        }


        public void Update()
        {
            _systems?.Run();
        }

#if UNITY_EDITOR
        private void OnApplicationQuit()
        {
            _saveSystems.Run();
        }

#else
        private void OnApplicationPause(bool pauseStatus)
        {
            _saveSystems.Run();
        }
#endif

        private void OnDestroy()
        {
            _systems?.Destroy();
            _systems = null;

            _saveSystems?.Destroy();
            _saveSystems = null;

            World?.Destroy();
            World = null;
        }
    }
}