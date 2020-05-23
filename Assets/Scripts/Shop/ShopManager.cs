using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : InventoryManager
{
    [Header("Shop stuff")]
    [SerializeField] private GameObject blankShopSlot;
    [SerializeField] private ShopInventory shopInventory;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button button;
    [SerializeField] private ShopItemValue shopItemValue;
    [SerializeField] private FloatValue playerMoney;
    [SerializeField] private SignalCore moneySignal;
    [SerializeField] private SignalCore pockedSignal;

    private void Update()
    {
        if (Input.GetButtonUp("Pause") && playerState.myState == GenericState.shop)
        {
            inventoryHolder.gameObject.SetActive(false);
            playerState.myState = GenericState.idle;
            ClearInventorySlots();
            Time.timeScale = 1;
        }
    }

    public void ShopOpen()
    {
        if (inventoryHolder.gameObject.activeInHierarchy)
        {
            inventoryHolder.gameObject.SetActive(false);
            playerState.myState = GenericState.idle;
            ClearInventorySlots();
            Time.timeScale = 1;
        }
        else
        {
            inventoryHolder.gameObject.SetActive(true);
            playerState.myState = GenericState.shop;
            MakeInventorySlots();
            Time.timeScale = 0.000001f;
        }
    }

    protected override void MakeInventorySlots()
    {
        base.MakeInventorySlots();
        if (shopInventory)
        {
            foreach (ShopItem item in shopInventory.list)
            {
                ShopSlot newSlot = Instantiate(blankShopSlot, transform.position, transform.rotation, shopPanel.transform)
                 .GetComponent<ShopSlot>();
                if (newSlot)
                {
                    newSlot.Setup(item, this);
                }
            }
        }
    }

    protected override void ClearInventorySlots()
    {
        base.ClearInventorySlots();
        for (int i = 0; i < shopPanel.transform.childCount; i++)
        {
            Destroy(shopPanel.transform.GetChild(i).gameObject);
        }
    }

    public override void UseButtonPressed()
    {
        if(button.GetComponentInChildren<TextMeshProUGUI>().text == "Buy")
        {
            if (shopItemValue.value)
            {
                if (playerMoney.value >= shopItemValue.value.thisItem.price)
                {
                    playerMoney.value -= shopItemValue.value.thisItem.price;
                    shopItemValue.value.Use();
                    if (!shopItemValue.value.infinity)
                    {
                        description.ClearDescriptionAndButton();
                    }
                }
                moneySignal.Raise();
            }
            ClearInventorySlots();
            MakeInventorySlots();
        }
        else if(button.GetComponentInChildren<TextMeshProUGUI>().text == "Sell")
        {
            if (currentItem.value)
            {
                playerInventory.Sell(currentItem.value);
                playerMoney.value += Mathf.RoundToInt(currentItem.value.price * 0.75f);
                if (currentItem.value.numberHeld <= 0)
                {
                    description.ClearDescriptionAndButton();
                }
                moneySignal.Raise();
                ClearInventorySlots();
                MakeInventorySlots();
            }
        }
        pockedSignal.Raise();
    }
}
