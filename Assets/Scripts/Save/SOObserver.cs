using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOObserver : MonoBehaviour
{
    public SOObserver instance;

    [SerializeField] private List<ScriptableObject> objectsInMemory;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
}
