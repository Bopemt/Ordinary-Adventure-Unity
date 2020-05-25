using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopDescription : InventoryDescription
{
    public ShopItemValue currentShopItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        currentShopItem.value = null;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        currentShopItem.value = null;
    }

    public override void SetupDescriptionAndButton(ShopItem newItem)
    {
        currentShopItem.value = newItem;
        descriptionText.text = newItem.thisItem.myDescription;
        nameText.text = newItem.thisItem.myName;
        useButton.interactable = !newItem.thisItem.unique;

        if (priceText)
        {
            priceText.text = "Price: " + newItem.thisItem.price;
        }

        if (currentShopItem.value.thisItem.weapon)
        {
            attackSpeedText.enabled = true;
            damageText.enabled = true;
            attackSpeedText.text = "AS: " + 0.3f / newItem.thisItem.attackDuration;
            damageText.text = "DMG: " + newItem.thisItem.damage;
        }
        else
        {
            attackSpeedText.enabled = false;
            damageText.enabled = false;
        }
        useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
    }

    public override void ClearDescriptionAndButton()
    {
        base.ClearDescriptionAndButton();
        currentShopItem.value = null;
    }
}
