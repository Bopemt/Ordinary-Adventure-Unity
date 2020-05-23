using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalSlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI questName;

    [Header("Variables from the quest")]
    public Quest thisQuest;
    public JournalManager thisManager;

    //public void Setup(Quest newQuest, JournalManager thisManager)
    //{
    //    thisItem = newItem;
    //    thisManager = newManager;
    //    if (thisItem)
    //    {
    //        itemImage.sprite = thisItem.mySprite;
    //        itemNumberText.text = thisItem.numberHeld.ToString();
    //    }
    //}

    //public void ClickedOn()
    //{
    //    if (thisItem)
    //    {
    //        thisManager.description.SetupDescriptionAndButton(thisItem);
    //    }
    //}
}
