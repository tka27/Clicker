using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Game.Scripts.Ecs
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private SceneData _sceneData;
        public static EcsWorld World { get; private set; }
        private IEcsSystems _systems;


        public void Start()
        {
            World = new EcsWorld();
            _systems = new EcsSystems(World);
            _systems
                .Inject(_sceneData)
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