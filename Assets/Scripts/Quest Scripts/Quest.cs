using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest : ScriptableObject
{
    [Header("Quest Stuff")]
    public int myOrderNumber;
    public string myName;
    public string myDescription;
    public float myLevel;
    public int currentAmount;
    public int requiredAmount;
    public bool inJournal;
    public bool isActive;
    public bool isComplete;

    [Header("Reward Stuff")]
    public InventoryItem myItem;
    public float myMoney;
    public float myExperience;

    [Header("Player Stuff")]
    public FloatValue playerMoney;
    public FloatValue playerExperience;
    public PlayerInventory playerInventory;

    [Header("Player Signal Stuff")]
    public SignalCore coinSignal;
    public SignalCore expSignal;
    public SignalCore questCompleteSignal;

    public void GiveReward()
    {
        if (myItem)
        {
            playerInventory.AddItem(myItem);
        }
        isActive = false;
        playerMoney.value += myMoney;
        playerExperience.value += myExperience;
        coinSignal.Raise();
        expSignal.Raise();
        questCompleteSignal.Raise();
    }

    public virtual void CheckQuest()
    {
        if (isComplete == false)
        {
            if (currentAmount >= requiredAmount)
            {
                GiveReward();
                isComplete = true;
            }
        }
    }
}
