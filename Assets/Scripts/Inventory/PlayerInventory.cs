using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    public List<InventoryItem> defaultInventory = new List<InventoryItem>();

    public void AddItem(InventoryItem newItem)
    {
        if (!myInventory.Contains(newItem))
        {
            myInventory.Add(newItem);
            newItem.numberHeld++;
        }
        else
        {
            newItem.numberHeld++;
        }
    }

    public void Sell(InventoryItem newItem)
    {
        if (myInventory.Contains(newItem))
        {
            if(newItem.numberHeld > 0)
            {
                newItem.numberHeld--;
            }
        }
    }

    public void RemoveItem(InventoryItem newItem)
    {
        if (myInventory.Contains(newItem))
        {
            myInventory.Remove(newItem);
        }
    }

    public void UseItem(InventoryItem newItem)
    {
        if (myInventory.Contains(newItem))
        {
            if (newItem.numberHeld > 0)
            {
                newItem.numberHeld--;
            }
        }
    }

    public bool IsItemInInventory(InventoryItem newItem)
    {
        return myInventory.Contains(newItem);
    }

    public bool canUseItem(InventoryItem newItem)
    {
        return newItem.numberHeld > 0;
    }

    public void CleanOutOfNull()
    {
        myInventory.RemoveAll(item => item == null);
        myInventory.RemoveAll(item => item.numberHeld <= 0);
    }

    public void Reset()
    {
        myInventory = defaultInventory;
    }
}
