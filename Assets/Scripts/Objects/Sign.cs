using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{
    [Header("Sign")]
    [SerializeField] protected string text;
    [SerializeField] protected string speakerName;
    [SerializeField] protected StringValue stringText;
    [SerializeField] protected StringValue stringName;
    [SerializeField] protected GenericStateMachine myState;
    [SerializeField] protected bool check = false;

    [Header("Dialog Stuff")]
    [SerializeField] protected SignalCore dialogSignal;

    protected virtual void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange && (myState.myState == GenericState.idle || myState.myState == GenericState.walk || myState.myState == GenericState.interact))
        {
            if (check == false)
            {
                check = !check;
                DisplayContents();
            }
            else
            {
                check = !check;
                DisableContents();
            }
        }
    }

    protected void DisplayContents()
    {
        stringName.value = speakerName;
        stringText.value = text;
        dialogSignal.Raise();
        myState.ChangeState(GenericState.interact);
        context.Raise();
        Time.timeScale = 0.000001f;
    }

    protected void DisableContents()
    {
        myState.ChangeState(GenericState.idle);
        dialogSignal.Raise();
        context.Raise();
        Time.timeScale = 1;
    }
}
