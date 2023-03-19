using Game.Scripts.MonoBehaviours;
using Game.Scripts.Savable;

namespace Game.Scripts.Ecs
{
    internal struct Business
    {
        public BusinessProvider Provider;
    }

    internal struct BusinessProgress
    {
        public FloatDataValueSavable ProgressTime;
    }
}