using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryDescription : Description
{
    [SerializeField] protected TextMeshProUGUI attackSpeedText;
    [SerializeField] protected TextMeshProUGUI damageText;
    [SerializeField] protected TextMeshProUGUI priceText;
    public ItemValue currentItem;

    protected override void OnEnable()
    {
        base.OnEnable();
        currentItem.value = null;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        currentItem.value = null;
    }

    public override void SetupDescriptionAndButton(InventoryItem newItem)
    {
        currentItem.value = newItem;
        descriptionText.text = newItem.myDescription;
        nameText.text = newItem.myName;

        if (currentItem.value.weapon)
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

        if (state.myState == GenericState.inventory)
        {
            useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Use";
            useButton.interactable = newItem.usable;
        }
        else if (state.myState == GenericState.shop)
        {
            useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell";
            useButton.interactable = !newItem.unique;
            if (priceText && !newItem.unique)
            {
                priceText.text = "Price: " + Mathf.RoundToInt(newItem.price * 0.75f);
            }
            else
            {
                priceText.text = "Price: ";
            }
        }
    }

    public override void ClearDescriptionAndButton()
    {
        base.ClearDescriptionAndButton();
        useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Use";
        currentItem.value = null;
        attackSpeedText.enabled = false;
        damageText.enabled = false;
        if (priceText)
        {
            priceText.text = "Price: ";
        }
    }
}
