using UnityEngine;

namespace Sigleton
{
    public class BaseSingleton<T> : MonoBehaviour where T : BaseSingleton<T>, new()
    {


        private static T instance;


        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                        instance.OnInitialize();
                    }
                }

                return instance;
            }

        }

        protected virtual void OnInitialize()
        {

        }
    }
}

