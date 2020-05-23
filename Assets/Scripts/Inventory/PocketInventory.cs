using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketInventory : MonoBehaviour
{
    public PlayerInventory pocketInventory;
    [SerializeField] private PocketSlot[] pocketSlots;
    [SerializeField] private GenericStateMachine playerState;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PlayerFloatValue playerDamage;
    [SerializeField] private CurrentWeaponSlot weaponSlot;
    [SerializeField] private Animation anim;
    private bool hided = false;
    private bool full = false;

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
     };

    private void Start()
    {
        //playerInventory.CleanOutOfNull();
        UpdateSlots();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Hide Pocket Inventory"))
        {
            if (Time.timeScale != 0)
            {
                if (hided)
                {
                    anim["Pocket Slide Down"].speed = -1f / Time.timeScale;
                    if (full)
                    {
                        anim["Pocket Slide Down"].time = anim["Pocket Slide Down"].length;
                    }
                    anim.Play("Pocket Slide Down");
                    hided = !hided;
                }
                else
                {
                    anim["Pocket Slide Down"].speed = 1f / Time.timeScale;
                    anim.Play("Pocket Slide Down");
                    hided = !hided;
                }
            }
        }
        else if (playerState.myState != GenericState.inventory && playerState.myState != GenericState.recieveItem && playerState.myState != GenericState.interact)
        {
            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    if (pocketInventory.myInventory[i])
                    {
                        pocketInventory.myInventory[i].Use();
                        if (pocketInventory.myInventory[i].weapon)
                        {
                            weaponSlot.UpdateImage();
                        }
                        else if (pocketInventory.myInventory[i].numberHeld <= 0)
                        {
                            playerInventory.RemoveItem(pocketInventory.myInventory[i]);
                            ClearSlot(pocketInventory.myInventory[i]);
                        }
                        Setup(pocketInventory.myInventory[i], i);
                    }
                }
            }
        }
    }

    public void SetWeaponDamage(ItemValue weapon)
    {
        if (weapon.value)
        {
            playerDamage.SetValue(weapon.value.damage);
        }
    }

    public void Setup(InventoryItem newItem,int numberOfSlot)
    {
        pocketInventory.myInventory[numberOfSlot] = newItem;
        pocketSlots[numberOfSlot].Setup(pocketInventory.myInventory[numberOfSlot]);
    }

    public void ClearSlot(InventoryItem item)
    {
        pocketSlots[ItemSlot(item)].Clear();
        pocketInventory.myInventory[ItemSlot(item)] = null;
    }

    public void UsePressed(InventoryItem item)
    {
        if (pocketInventory.myInventory.Contains(item))
        {
            Setup(item, ItemSlot(item));
        }
    }

    public int ItemSlot(InventoryItem item)
    {
        return pocketInventory.myInventory.IndexOf(item);
    }

    public void UpdateSlots()
    {
        for(int i = 0; i < 6; i++)
        {
            Setup(pocketInventory.myInventory[i], i);
            if (pocketInventory.myInventory[i])
            {
                if (pocketInventory.myInventory[i].numberHeld <= 0)
                {
                    ClearSlot(pocketInventory.myInventory[i]);
                }
            }
        }
    }

    public void SetFullTrue()
    {
        full = true;
    }

    public void SetFullFalse()
    {
        full = false;
    }
}
