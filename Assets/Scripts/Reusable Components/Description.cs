using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI descriptionText;
    [SerializeField] protected TextMeshProUGUI nameText;
    [SerializeField] protected Button useButton;
    [SerializeField] protected GenericStateMachine state;

    protected virtual void OnEnable()
    {
        ClearDescriptionAndButton();
    }

    protected virtual void OnDisable()
    {
        ClearDescriptionAndButton();
    }

    public virtual void ClearDescriptionAndButton()
    {
        descriptionText.text = "";
        nameText.text = "";
        useButton.interactable = false;
    }

    public virtual void SetupDescriptionAndButton(InventoryItem newItem)
    {

    }

    public virtual void SetupDescriptionAndButton(ShopItem newItem)
    {

    }

    public virtual void SetupDescriptionAndButton(Quest newItem)
    {

    }
}
