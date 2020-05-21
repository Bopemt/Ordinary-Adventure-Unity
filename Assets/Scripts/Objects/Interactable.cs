using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected bool playerInRange;
    [SerializeField] public SignalCore context;
    [SerializeField] protected string otherTag;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
