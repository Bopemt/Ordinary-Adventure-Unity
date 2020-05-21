using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLoot : MonoBehaviour
{
    [SerializeField] private LootTable thisLoot;

    public void DropLoot()
    {
        if (thisLoot != null)
        {
            GameObject current = thisLoot.LootPowerUp();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }
}
