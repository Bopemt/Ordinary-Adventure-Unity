using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    public FloatValue playerHealth;

    public void SetMaxHealth()
    {
        slider.maxValue = playerHealth.initialValue;
        slider.value = playerHealth.RuntimeValue;
        text.text = playerHealth.RuntimeValue + "/" + playerHealth.initialValue;
    }

    public void SetHealth()
    {
        slider.value = playerHealth.RuntimeValue;
        text.text = playerHealth.RuntimeValue + "/" + playerHealth.initialValue;
    }

    private void Start()
    {
        SetMaxHealth();
        SetHealth();
    }

    //private void Update()
    //{
    //    SetHealth();
    //}
}
