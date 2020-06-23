using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Door : Sign
//{
//    [Header("Door Stuff")]
//    [SerializeField] protected bool isOpened = false;
//    [SerializeField] protected SpriteRenderer doorSprite;
//    [SerializeField] protected BoxCollider2D physicsCollider;

//    public virtual void Open()
//    {
//        doorSprite.enabled = false;
//        isOpened = true;
//        physicsCollider.enabled = false;
//    }

//    public void Close()
//    {
//        doorSprite.enabled = true;
//        isOpened = false;
//        physicsCollider.enabled = true;
//    }

//    protected override void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
//        {
//            playerInRange = true;
//            if (!isOpened)
//            {
//                context.Raise();
//            }
//        }
//    }

//    protected override void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
//        {
//            playerInRange = false;
//            if (!isOpened)
//            {
//                context.Raise();
//            }
//        }
//    }
//}

public class Door : Interactable
{
    [Header("Door Stuff")]
    [SerializeField] protected bool isOpened = false;
    [SerializeField] protected SpriteRenderer doorSprite;
    [SerializeField] protected BoxCollider2D physicsCollider;

    [Header("Sign")]
    [SerializeField] protected string text;
    [SerializeField] protected string speakerName;
    [SerializeField] protected StringValue stringText;
    [SerializeField] protected StringValue stringName;
    [SerializeField] protected GenericStateMachine myState;
    [SerializeField] protected bool check = false;

    [Header("Dialog Stuff")]
    [SerializeField] protected SignalCore dialogSignal;

    public virtual void Open()
    {
        doorSprite.enabled = false;
        isOpened = true;
        physicsCollider.enabled = false;
    }

    public void Close()
    {
        doorSprite.enabled = true;
        isOpened = false;
        physicsCollider.enabled = true;
    }

    protected virtual void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange && (myState.myState == GenericState.idle || myState.myState == GenericState.walk || myState.myState == GenericState.interact))
        {
            if (!check)
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

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            if (!isOpened)
            {
                context.Raise();
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = false;
            if (!isOpened)
            {
                context.Raise();
            }
        }
    }
}
