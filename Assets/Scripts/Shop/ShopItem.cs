using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(fileName = "NewShopItem", menuName = "Inventory/Shop Item")]
public class ShopItem : ScriptableObject
{
    public InventoryItem thisItem;
    public bool infinity;
    public UnityEvent thisEvent;

    public void Use()
    {
        thisEvent.Invoke();
    }
}
