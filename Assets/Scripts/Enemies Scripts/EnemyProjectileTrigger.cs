using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileTrigger : GenericHealth
{
    [SerializeField] private EnemyHealth enemyHealth;

    public override void Damage(float amountToDamage)
    {
        enemyHealth.Damage(amountToDamage);
    }
}
