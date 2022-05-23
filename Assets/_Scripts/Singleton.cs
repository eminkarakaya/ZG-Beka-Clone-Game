using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
            }
            return _instance;
        }
    }
}
