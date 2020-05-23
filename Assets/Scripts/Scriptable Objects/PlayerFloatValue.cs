using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Values/Player Float Value", fileName = "New Player Float Value")]
public class PlayerFloatValue : FloatValue
{
    public FloatValue playerLevel;
    public float characteristicPerLevel;

    protected override void OnEnable()
    {
        SetValue(defaultValue);
    }

    public new void SetValue(float newValue)
    {
        maxValue = defaultValue + playerLevel.value * characteristicPerLevel;
        value = playerLevel.value * characteristicPerLevel + newValue;
    }

    public void LevelUp()
    {
        maxValue = defaultValue + playerLevel.value * characteristicPerLevel;
        value = playerLevel.value * characteristicPerLevel + defaultValue;
    }
}
