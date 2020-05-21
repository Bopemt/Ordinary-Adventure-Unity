using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Vector Value", fileName = "New String Value")]
[System.Serializable]
public class VectorValue : ScriptableObject
{
    [SerializeField] private Vector2 defaultValue;

    public Vector2 value;

    private void OnEnable()
    {
        value = defaultValue;
    }
}
