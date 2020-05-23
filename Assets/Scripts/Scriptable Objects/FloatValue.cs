using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Float Value", fileName = "New Float Value")]
[System.Serializable]
public class FloatValue : ScriptableObject
{
    public float defaultValue;

    public float maxValue;
    
    public float value;

    protected virtual void OnEnable()
    {
        maxValue = defaultValue;
        value = maxValue;
    }

    public void SetValue(float newValue)
    {
        value = newValue;
    }
}
