using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PocketSlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;

    [Header("Variables from the item")]
    public InventoryItem thisItem;

    public void Setup(InventoryItem newItem)
    {
        thisItem = newItem;
        if (thisItem)
        {
            itemImage.sprite = thisItem.mySprite;
            itemNumberText.text = thisItem.numberHeld.ToString();
            itemImage.enabled = true;
        }
    }

    public void Clear()
    {
        itemNumberText.text = "";
        itemImage.enabled = false;
    }
}
