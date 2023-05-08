using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
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