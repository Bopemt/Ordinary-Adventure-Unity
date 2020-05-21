using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreasureChest : Interactable
{
    [SerializeField] private AnimatorController anim;
    [SerializeField] private BoolValue storedOpen;
    [SerializeField] private bool isOpen;
    [SerializeField] private SignalCore chestSignal;
    [SerializeField] private SpriteValue spriteValue;
    [SerializeField] private StringValue stringText;
    [SerializeField] private StringValue stringName;
    [SerializeField] private InventoryItem myItem;
    [SerializeField] private PlayerInventory playerInventory;
    
    void Start()
    {
        isOpen = storedOpen.value;
        if (isOpen)
        {
            anim.anim.Play("chest_Open_Idle", 0, 1.0f);
        }
    }
    
    void Update()
    {
        if (playerInRange && Input.GetButtonUp("Interact"))
        {
            if (isOpen)
            {
                return;
            }
            OpenChest();
        }
    }

    public void OpenChest()
    {
        isOpen = !isOpen;
        anim.SetAnimParameter("opened", true);
        storedOpen.value = isOpen;
        spriteValue.value = myItem.mySprite;
        stringText.value = myItem.myDescription;
        stringName.value = "";
        chestSignal.Raise();
        playerInventory.AddItem(myItem);
        context.Raise();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && !other.isTrigger)
        {
            playerInRange = true;
            if (!isOpen)
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
            if (!isOpen)
            {
                context.Raise();
            }
        }
    }
}
