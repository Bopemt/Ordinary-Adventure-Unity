using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : InventoryManager
{
    [Header("Description & Use Stuff")]

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
            ShopOpen();
        }
    }

    public void ShopOpen()
    {
        if (panelHolder.gameObject.activeInHierarchy)
        {
            panelHolder.gameObject.SetActive(false);
            playerState.myState = GenericState.idle;
            ClearSlots(slotsPanel);
            ClearSlots(shopPanel);
            Time.timeScale = 1;
        }
        else
        {
            panelHolder.gameObject.SetActive(true);
            playerState.myState = GenericState.shop;
            MakeSlots(playerInventory.myInventory, blankSlot, slotsPanel);
            MakeSlots(shopInventory.list, blankShopSlot, shopPanel);
            Time.timeScale = 0.000001f;
        }
    }

    protected void MakeSlots(List<ShopItem> list, GameObject _blankSlot, GameObject slotPanel)
    {
        foreach (ShopItem item in list)
        {
            ShopSlot newSlot = Instantiate(_blankSlot, transform.position, transform.rotation, slotPanel.transform)
             .GetComponent<ShopSlot>();
            if (newSlot)
            {
                newSlot.Setup(item, this);
            }
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
            ClearSlots(slotsPanel);
            ClearSlots(shopPanel);
            MakeSlots(playerInventory.myInventory, blankSlot, slotsPanel);
            MakeSlots(shopInventory.list, blankShopSlot, shopPanel);
        }
        else if(button.GetComponentInChildren<TextMeshProUGUI>().text == "Sell")
        {
            if (currentItem.value)
            {
                playerInventory.Sell(currentItem.value);
                playerMoney.value += Mathf.RoundToInt(currentItem.value.price * 0.75f);
                if (currentItem.value.numberHeld <= 0)
                {
                    playerInventory.RemoveItem(currentItem.value);
                    description.ClearDescriptionAndButton();
                }
                moneySignal.Raise();
                ClearSlots(slotsPanel);
                ClearSlots(shopPanel);
                MakeSlots(playerInventory.myInventory, blankSlot, slotsPanel);
                MakeSlots(shopInventory.list, blankShopSlot, shopPanel);
            }
        }
        pockedSignal.Raise();
    }
}
