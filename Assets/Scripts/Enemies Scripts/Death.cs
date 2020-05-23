using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private SignalCore deathSignal;
    [SerializeField] private FloatValue playerExp;
    [SerializeField] private float experience;

    public void Die()
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
        if (playerExp)
        {
            playerExp.value += experience;
        }
        if (deathSignal)
        {
            deathSignal.Raise();
        }
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        this.transform.parent.gameObject.SetActive(false);
        Destroy(effect, 1f);
    }
}
