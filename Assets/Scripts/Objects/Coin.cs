using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{
    public FloatValue coinCount;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            coinCount.value += 10;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
