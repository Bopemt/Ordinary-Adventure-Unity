using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/String Value", fileName = "New String Value")]
public class StringValue : ScriptableObject
{
    public string defaultValue;

    public string value;
}
