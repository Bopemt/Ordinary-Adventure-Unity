using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Stuff")]
    public PlayerInventory playerInventory;
    [SerializeField] protected GameObject blankInventorySlot;
    [SerializeField] protected GameObject inventoryPanel;
    [SerializeField] protected GameObject inventoryHolder;
    [SerializeField] protected GenericStateMachine playerState;
    [SerializeField] protected PocketInventory pocketInventory;

    [Header("Description & Use Stuff")]
    public Description description;
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
            if (inventoryHolder.gameObject.activeInHierarchy)
            {
                inventoryHolder.gameObject.SetActive(false);
                playerState.myState = GenericState.idle;
                ClearInventorySlots();
                Time.timeScale = 1;
            }
            else
            {
                inventoryHolder.gameObject.SetActive(true);
                playerState.myState = GenericState.inventory;
                MakeInventorySlots();
                Time.timeScale = 0.000001f;
            }
        }
        else if (Input.GetButtonUp("Pause") && playerState.myState == GenericState.inventory)
        {
            inventoryHolder.gameObject.SetActive(false);
            playerState.myState = GenericState.idle;
            ClearInventorySlots();
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

    protected virtual void MakeInventorySlots()
    {
        if (playerInventory)
        {
            foreach(InventoryItem item in playerInventory.myInventory)
            {
                if (item.numberHeld > 0)
                {
                    InventorySlot newSlot = Instantiate(blankInventorySlot, transform.position, transform.rotation, inventoryPanel.transform)
                     .GetComponent<InventorySlot>();
                    if (newSlot)
                    {
                        newSlot.Setup(item, this);
                    }
                }
            }
        }
    }

    protected virtual void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
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
            ClearInventorySlots();
            MakeInventorySlots();
        }
    }
}
