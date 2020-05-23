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

    public void SetHealth()
    {
        slider.maxValue = playerHealth.maxValue;
        slider.value = playerHealth.value;
        text.text = playerHealth.value + "/" + playerHealth.maxValue;
    }

    private void Start()
    {
        SetHealth();
    }
}
