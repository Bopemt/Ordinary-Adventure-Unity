using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSignal : MonoBehaviour
{
    [SerializeField] public SignalCore experienceSignal;

    public void DeathCheck()
    {
        if (gameObject.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            experienceSignal.Raise();
        }
    }
}
