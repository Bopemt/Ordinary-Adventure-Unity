using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoard : Interactable
{
    [SerializeField] private GenericStateMachine playerState;
    [SerializeField] private SignalCore questBoardSignal;

    protected virtual void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange
            && (playerState.myState == GenericState.walk || playerState.myState == GenericState.idle || playerState.myState == GenericState.journal))
        {
            questBoardSignal.Raise();
        }
    }
}
