using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Sign
{
    [Header("Door Stuff")]
    [SerializeField] protected bool isOpened = false;
    [SerializeField] protected SpriteRenderer doorSprite;
    [SerializeField] protected BoxCollider2D physicsCollider;

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
