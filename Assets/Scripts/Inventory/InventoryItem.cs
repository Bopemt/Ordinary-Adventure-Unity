using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    [Header("Typically Item Stuff")]
    public string myName;
    public string myDescription;
    public Sprite mySprite;
    public float price;
    public int numberHeld;
    public bool usable;
    public bool unique;
    public bool pocket;

    [Header("Weapon Stuff")]
    public bool weapon;
    public bool rangeWeapon;
    public float attackDuration;
    public float damage;
    public float energyCost;
    public UnityEvent thisEvent;

    public void Use()
    {
        thisEvent.Invoke();
    }
}
