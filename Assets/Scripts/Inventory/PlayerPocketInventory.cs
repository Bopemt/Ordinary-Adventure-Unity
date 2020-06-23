using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Pocket Inventory", menuName = "Inventory/Player Pocket Inventory")]
public class PlayerPocketInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    public List<InventoryItem> defaultInventory = new List<InventoryItem>();
    
    public void Reset()
    {
        myInventory = defaultInventory;
    }
}
