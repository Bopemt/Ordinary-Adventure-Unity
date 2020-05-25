using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : SlotManager
{
    [Header("Inventory Stuff")]
    public PlayerInventory playerInventory;
    [SerializeField] protected PocketInventory pocketInventory;

    [Header("Description & Use Stuff")]
    public InventoryDescription description;
    public ItemValue currentItem;

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
     };

    private void Update()
    {
        if (Input.GetButtonDown("Inventory") && (playerState.myState == GenericState.idle || playerState.myState == GenericState.walk || playerState.myState == GenericState.inventory))
        {
            if (panelHolder.gameObject.activeInHierarchy)
            {
                panelHolder.gameObject.SetActive(false);
                playerState.myState = GenericState.idle;
                ClearSlots(slotsPanel);
                Time.timeScale = 1;
            }
            else
            {
                panelHolder.gameObject.SetActive(true);
                playerState.myState = GenericState.inventory;
                MakeSlots(playerInventory.myInventory, blankSlot, slotsPanel);
                Time.timeScale = 0.000001f;
            }
        }
        else if (Input.GetButtonUp("Pause") && playerState.myState == GenericState.inventory)
        {
            panelHolder.gameObject.SetActive(false);
            playerState.myState = GenericState.idle;
            ClearSlots(slotsPanel);
            Time.timeScale = 1;
        }
        else if (currentItem.value && playerState.myState == GenericState.inventory)
        {
            if (currentItem.value.pocket)
            {
                for (int i = 0; i < keyCodes.Length; i++)
                {
                    if (Input.GetKeyDown(keyCodes[i]))
                    {
                        if (pocketInventory.pocketInventory.myInventory.Contains(currentItem.value))
                        {
                            pocketInventory.ClearSlot(currentItem.value);
                        }
                        pocketInventory.Setup(currentItem.value, i);
                    }
                }
            }
        }
    }

    protected void MakeSlots(List<InventoryItem> list, GameObject _blankSlot, GameObject slotPanel)
    {
        foreach (InventoryItem item in list)
        {
            if (item.numberHeld > 0)
            {
                InventorySlot newSlot = Instantiate(_blankSlot, transform.position, transform.rotation, slotPanel.transform)
                 .GetComponent<InventorySlot>();
                if (newSlot)
                {
                    newSlot.Setup(item, this);
                }
            }
        }
    }

    public virtual void UseButtonPressed()
    {
        if (currentItem.value)
        {
            currentItem.value.Use();
            if (currentItem.value.numberHeld <= 0)
            {
                if (pocketInventory.pocketInventory.myInventory.Contains(currentItem.value))
                {
                    pocketInventory.ClearSlot(currentItem.value);
                }
                playerInventory.RemoveItem(currentItem.value);
                description.ClearDescriptionAndButton();
            }
            if (pocketInventory.pocketInventory.myInventory.Contains(currentItem.value))
            {
                pocketInventory.UsePressed(currentItem.value);
            }
            ClearSlots(slotsPanel);
            MakeSlots(playerInventory.myInventory, blankSlot, slotsPanel);
        }
    }
}
