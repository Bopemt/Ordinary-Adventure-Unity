using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private FloatValue playerEnergy;

    public void SetMaxEnergy()
    {
        slider.maxValue = playerEnergy.defaultValue;
        slider.value = playerEnergy.value;
    }

    public void SetEnergy()
    {
        slider.value = playerEnergy.value;
    }

    private void Start()
    {
        SetMaxEnergy();
        SetEnergy();
    }
}
