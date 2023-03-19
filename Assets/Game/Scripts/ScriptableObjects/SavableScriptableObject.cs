using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    public abstract class SavableScriptableObject : ScriptableObject
    {
        public abstract void Save();
    }
}