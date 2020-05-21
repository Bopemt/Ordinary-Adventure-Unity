using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Stuff")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryHolder;
    [SerializeField] private GenericStateMachine playerState;
    [SerializeField] private PocketInventory pocketInventory;

    [Header("Description & Use Stuff")]
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI attackSpeedText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private Button useButton;
    public InventoryItem currentItem;

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
                ClearDescriptionAndButton();
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
        else if (currentItem && playerState.myState == GenericState.inventory)
        {
            if (currentItem.pocket)
            {
                for (int i = 0; i < keyCodes.Length; i++)
                {
                    if (Input.GetKeyDown(keyCodes[i]))
                    {
                        if (pocketInventory.pocketInventory.myInventory.Contains(currentItem))
                        {
                            pocketInventory.ClearSlot(currentItem);
                        }
                        pocketInventory.Setup(currentItem, i);
                    }
                }
            }
        }
    }

    void MakeInventorySlots()
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

    //private void OnEnable()
    //{
    //    MakeInventorySlots();
    //    ClearDescriptionAndButton();
    //    Time.timeScale = 0.000001f;
    //}

    //private void OnDisable()
    //{
    //    ClearInventorySlots();
    //    Time.timeScale = 1;
    //}

    public void SetupDescriptionAndButton(InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newItem.myDescription;
        nameText.text = newItem.myName;
        useButton.interactable = newItem.usable;
        if (currentItem.weapon)
        {
            attackSpeedText.enabled = true;
            damageText.enabled = true;
            attackSpeedText.text = "AS: " + 0.3f / newItem.attackDuration;
            damageText.text = "DMG: " + newItem.damage;
        }
        else
        {
            attackSpeedText.enabled = false;
            damageText.enabled = false;
        }
    }

    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    void ClearDescriptionAndButton()
    {
        currentItem = null;
        descriptionText.text = "";
        nameText.text = "";
        useButton.interactable = false;
        attackSpeedText.enabled = false;
        damageText.enabled = false;
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            playerInventory.UseItem(currentItem);
            if (currentItem.numberHeld <= 0)
            {
                if (pocketInventory.pocketInventory.myInventory.Contains(currentItem))
                {
                    pocketInventory.ClearSlot(currentItem);
                }
                playerInventory.RemoveItem(currentItem);
                ClearDescriptionAndButton();
            }
            if (pocketInventory.pocketInventory.myInventory.Contains(currentItem))
            {
                pocketInventory.UsePressed(currentItem);
            }
            ClearInventorySlots();
            MakeInventorySlots();
        }
    }
}
