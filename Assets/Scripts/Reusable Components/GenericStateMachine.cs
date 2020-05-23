using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GenericState
{
    idle,
    walk,
    attack,
    stun,
    dead,
    recieveItem,
    interact,
    inventory,
    ability,
    pause,
    shop
}

public class GenericStateMachine : MonoBehaviour
{
    public GenericState myState;

    public void ChangeState(GenericState newState)
    {
        if (myState != newState)
        {
            myState = newState;
        }
    }
}
