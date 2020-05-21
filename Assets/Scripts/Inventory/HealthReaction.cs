using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReaction : MonoBehaviour
{
    [SerializeField] private FloatValue playerHealth;
    [SerializeField] private SignalCore healthSignal;

    public void Use(int amountToIncrease)
    {
        playerHealth.value += amountToIncrease;
        if (playerHealth.value > playerHealth.defaultValue)
        {
            playerHealth.value = playerHealth.defaultValue;
        }
        healthSignal.Raise();
    }
}
