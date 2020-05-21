using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GenericHealth
{
    [SerializeField] private GameObject deathEffect;

    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);
        if(currentHealth <= 0)
        {
            MakeLoot loot = GetComponent<MakeLoot>();
            if (loot)
            {
                loot.DropLoot();
            }
            RoomDeathSignal temp = GetComponent<RoomDeathSignal>();
            if (temp)
            {
                temp.roomSignal.Raise();
            }
            Die();
        }
    }

    public void Die()
    {
        this.transform.parent.gameObject.SetActive(false);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }
}
