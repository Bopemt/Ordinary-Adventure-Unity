using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : PowerUp
{
    public FloatValue playerHealth;
    public float amountToIncrease;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            
            if(playerHealth.RuntimeValue > playerHealth.initialValue)
            {
                playerHealth.RuntimeValue = playerHealth.initialValue;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
