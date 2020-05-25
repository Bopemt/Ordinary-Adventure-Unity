using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    [SerializeField] private Image itemImage;

    [Header("Variables from the item")]
    public ShopItem thisItem;
    public ShopManager thisManager;

    public void Setup(ShopItem newItem, ShopManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem)
        {
            itemImage.sprite = thisItem.thisItem.mySprite;
        }
    }

    public void ClickedOn()
    {
        if (thisItem)
        {
            thisManager.description.SetupDescriptionAndButton(thisItem);
        }
    }
}
