using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{
    public SignalCore healthSignal;
    public GenericFlashColor flash;

    public override void Start()
    {
        currentHealth = health.value;
    }

    public override void Damage(float amountToDamage)
    {
        health.value -= amountToDamage;
        if(health.value <= 0)
        {
            health.value = 0;
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            if (flash)
            {
                flash.StartFlash();
            }
        }
        currentHealth = health.value;
        healthSignal.Raise();
    }

    public override void Heal(float amountToHeal)
    {
        base.Heal(amountToHeal);
        health.value = currentHealth;
        healthSignal.Raise();
    }

    public override void FullHeal()
    {
        health.value = health.maxValue;
        currentHealth = health.value;
        healthSignal.Raise();
    }
}
