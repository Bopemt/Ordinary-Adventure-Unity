using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private FloatValue playerLevel;
    [SerializeField] private FloatValue playerExp;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    
    void Start()
    {
        UpdateValue();
    }

    public void UpdateValue()
    {
        slider.maxValue = levelSystem.expToNextLvl;
        slider.value = playerExp.value;
        levelText.text = playerLevel.value.ToString();
        expText.text = playerExp.value + "/" + slider.maxValue;
    }

    public void UpdateValueLate()
    {
        Invoke("UpdateValue", 0.001f);
    }
}
