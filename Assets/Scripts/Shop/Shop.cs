using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    [SerializeField] private GenericStateMachine playerState;
    [SerializeField] private SignalCore shopSignal;

    protected virtual void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange 
            && (playerState.myState == GenericState.walk || playerState.myState == GenericState.idle || playerState.myState == GenericState.shop))
        {
            shopSignal.Raise();
        }
    }
}
