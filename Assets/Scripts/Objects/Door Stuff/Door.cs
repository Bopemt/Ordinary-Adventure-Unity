using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    //public DoorType thisDoorType;
    public bool isOpened = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    public void Open()
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

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpened)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpened)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
