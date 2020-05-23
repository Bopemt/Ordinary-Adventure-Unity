using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI attackSpeedText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button useButton;
    [SerializeField] private GenericStateMachine state;
    public ItemValue currentItem;
    public ShopItemValue currentShopItem;

    private void OnEnable()
    {
        currentShopItem.value = null;
        currentItem.value = null;
        ClearDescriptionAndButton();
    }

    private void OnDisable()
    {
        currentShopItem.value = null;
        currentItem.value = null;
        ClearDescriptionAndButton();
    }

    public void SetupDescriptionAndButton(InventoryItem newItem)
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

        if(state.myState == GenericState.inventory)
        {
            useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Use";
            useButton.interactable = newItem.usable;
        }
        else if(state.myState == GenericState.shop)
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

    public void SetupDescriptionAndButton(ShopItem newItem, bool shop)
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
        if (shop)
        {
            useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
        }
    }

    public void ClearDescriptionAndButton()
    {
        currentItem.value = null;
        currentShopItem.value = null;
        descriptionText.text = "";
        nameText.text = "";
        useButton.interactable = false;
        useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Use";
        attackSpeedText.enabled = false;
        damageText.enabled = false;
        if (priceText)
        {
            priceText.text = "Price: ";
        }
    }
}
