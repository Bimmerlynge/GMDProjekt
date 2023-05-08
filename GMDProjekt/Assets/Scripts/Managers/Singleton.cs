using UnityEngine;

namespace Managers
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        public static T Instance;

        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}