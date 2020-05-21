using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private SpriteValue recievedSprite;
    [SerializeField] private AnimatorController anim;
    [SerializeField] private GenericStateMachine myState;
    [SerializeField] private bool isActive = false;

    [Header("Dialog Stuff")]
    [SerializeField] private SignalCore dialogSignal;

    private void Start()
    {
        mySprite.enabled = false;
    }

    public void ChangeSpriteState()
    {
        isActive = !isActive;
        if (isActive)
        {
            DisplaySprite();
        }
        else
        {
            DisableSprite();
        }
    }

    void DisplaySprite()
    {
        myState.ChangeState(GenericState.recieveItem);
        mySprite.enabled = true;
        mySprite.sprite = recievedSprite.value;
        anim.SetAnimParameter("recieveItem", true);
        dialogSignal.Raise();
    }

    void DisableSprite()
    {
        myState.ChangeState(GenericState.idle);
        mySprite.enabled = false;
        dialogSignal.Raise();
    }
}
