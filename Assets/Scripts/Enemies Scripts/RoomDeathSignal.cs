using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDeathSignal : MonoBehaviour
{
    [Header("Death Signals")]
    [SerializeField] public SignalCore roomSignal;

    void Update()
    {
        if(gameObject.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            roomSignal.Raise();
        }
    }
}
