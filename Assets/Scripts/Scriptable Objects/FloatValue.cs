using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Float Value", fileName = "New String Value")]
[System.Serializable]
public class FloatValue : ScriptableObject
{
    public float defaultValue;
    
    public float value;

    private void OnEnable()
    {
        value = defaultValue;
    }
}
