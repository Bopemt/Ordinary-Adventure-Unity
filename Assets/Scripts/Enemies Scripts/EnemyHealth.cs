using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GenericHealth
{
    //[SerializeField] private GameObject deathEffect;
    //[SerializeField] private SignalCore deathSignal;
    [SerializeField] private Death death;

    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);
        if(currentHealth <= 0)
        {
            death.Die();
        }
    }
}
