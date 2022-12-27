using UnityEngine;

namespace Mechanics
{
    public abstract class SingletonBase : MonoBehaviour
    {
        public abstract void Initialize();
        protected virtual void BootOrderAwake() => print(GetType().Name + " initialized.");
    }
    public class Singleton <T> : SingletonBase where T : MonoBehaviour
    {
        public static T Instance { get; protected set; }
        protected virtual void SetInstance(T instance) => Instance = instance;
        
        public override void Initialize()
        {
            if (Instance == null)
                SetInstance(this as T);
            else Destroy(this);
            
            BootOrderAwake();
        }
    }
    public class SingletonDontDestroy <T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void SetInstance(T instance)
        {
            Instance = instance;
            DontDestroyOnLoad(instance);
        }
    }
}