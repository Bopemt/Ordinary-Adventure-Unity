using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Bool Value", fileName = "New String Value")]
[System.Serializable]
public class BoolValue : ScriptableObject
{
    public bool defaultValue;
    
    public bool value;

    private void OnEnable()
    {
        value = defaultValue;
    }
}
