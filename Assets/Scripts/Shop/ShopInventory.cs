using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Shop Inventory", menuName = "Inventory/Shop Inventory")]
public class ShopInventory : ScriptableObject
{
    public List<ShopItem> list = new List<ShopItem>();

    public void CleanOutOfNull()
    {
        list.RemoveAll(item => item == null);
        list.RemoveAll(item => item.thisItem == null);
        list.RemoveAll(item => item.thisItem.numberHeld <= 0);
    }

    public void RemoveItem(ShopItem newItem)
    {
        if (list.Contains(newItem))
        {
            list.Remove(newItem);
        }
    }

    public void UseItem(ShopItem newItem)
    {
        if (list.Contains(newItem))
        {
            newItem.Use();
            if (!newItem.infinity)
            {
                list.Remove(newItem);
            }
        }
    }
}
