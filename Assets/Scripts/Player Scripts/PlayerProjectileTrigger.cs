using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileTrigger : GenericHealth
{
    [SerializeField] private PlayerHealth playerHealth;

    public override void Damage(float amountToDamage)
    {
        //playerHealth.currentHealth -= amountToDamage;
        //if (playerHealth.currentHealth < 0)
        //{
        //    playerHealth.currentHealth = 0;
        //}
        //else
        //{
        //    if (playerHealth.flash)
        //    {
        //        playerHealth.flash.StartFlash();
        //    }
        //}
        //playerHealth.health.value = playerHealth.currentHealth;
        //playerHealth.healthSignal.Raise();
        playerHealth.Damage(amountToDamage);
    }
}
