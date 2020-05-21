using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private FloatValue playerHealth;

    public void SetMaxHealth()
    {
        slider.maxValue = playerHealth.defaultValue;
        slider.value = playerHealth.value;
        text.text = playerHealth.value + "/" + playerHealth.defaultValue;
    }

    public void SetHealth()
    {
        slider.value = playerHealth.value;
        text.text = playerHealth.value + "/" + playerHealth.defaultValue;
    }

    private void Start()
    {
        SetMaxHealth();
        SetHealth();
    }
}
