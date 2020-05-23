using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDeathSignal : MonoBehaviour
{
    [SerializeField] public SignalCore roomSignal;

    public void DeathCheck()
    {
        if(gameObject.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            roomSignal.Raise();
        }
    }
}
