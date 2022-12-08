using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.LogError($"Cannot find the instance of {typeof(T).FullName}");
                }
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else if (instance != this)
        {
            Debug.LogError($"Duplicate instance of {typeof(T).FullName}");
        }
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }
}