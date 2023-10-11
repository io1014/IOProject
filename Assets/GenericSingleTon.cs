using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleTon<T> : MonoBehaviour where T : MonoBehaviour 
{
    public static GenericSingleTon<T> Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            OnWake();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    protected virtual void OnWake() { }
}

