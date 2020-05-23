using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    [SerializeField] private PlayerFloatValue playerHealth;
    [SerializeField] private SignalCore healthSignal;

    public void Use(int amountToIncrease)
    {
        playerHealth.value += amountToIncrease;
        if (playerHealth.value > playerHealth.maxValue)
        {
            playerHealth.value = playerHealth.maxValue;
        }
        healthSignal.Raise();
    }
}
