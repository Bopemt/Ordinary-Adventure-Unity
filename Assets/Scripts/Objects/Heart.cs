using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : PowerUp
{
    public PlayerFloatValue playerHealth;
    public float amountToIncrease;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.value += amountToIncrease;
            if(playerHealth.value > playerHealth.maxValue)
            {
                playerHealth.value = playerHealth.maxValue;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
