using System;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);

                _instance = (T)FindObjectOfType(t);
                if (_instance == null)
                {
                    Debug.Log(t + " をアタッチしているGameObjectはありません");
                }
            }

            return _instance;
        }
    }

    public static bool HasInstance { get { return Instance != null; }}

    virtual protected void Awake ()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
    }

    protected virtual void OnDestroy()
    {
        if(_instance == this) {
            _instance = null;
        }
    }
}