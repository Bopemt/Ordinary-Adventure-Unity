using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    //public Slider slider;
    //public Inventory playerInventory;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    slider.maxValue = playerInventory.maxEnergy;
    //    slider.value = playerInventory.maxEnergy;
    //    playerInventory.currentEnergy = playerInventory.maxEnergy;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    RecoveryEnergy();
    //}

    //public void AddEnergy(float energyIncome)
    //{
    //    playerInventory.currentEnergy += energyIncome;
    //    slider.value = playerInventory.currentEnergy;
    //    if (playerInventory.currentEnergy > playerInventory.maxEnergy)
    //    {
    //        playerInventory.currentEnergy = playerInventory.maxEnergy;
    //        slider.value = playerInventory.maxEnergy;
    //    }
    //}

    //public void RecoveryEnergy()
    //{
    //    playerInventory.currentEnergy += playerInventory.energyRecoverySpeed;
    //    slider.value = playerInventory.currentEnergy;
    //    if (playerInventory.currentEnergy > playerInventory.maxEnergy)
    //    {
    //        playerInventory.currentEnergy = playerInventory.maxEnergy;
    //        slider.value = playerInventory.maxEnergy;
    //    }
    //}

    //public void DecreaseEnergy(float energyCost)
    //{
    //    playerInventory.currentEnergy -= energyCost;
    //    slider.value = playerInventory.currentEnergy;
    //}

    public Slider slider;
    public FloatValue playerEnergy;

    public void SetMaxEnergy()
    {
        slider.maxValue = playerEnergy.initialValue;
        slider.value = playerEnergy.RuntimeValue;
    }

    public void SetEnergy()
    {
        slider.value = playerEnergy.RuntimeValue;
    }

    private void Start()
    {
        SetMaxEnergy();
        SetEnergy();
    }
}
