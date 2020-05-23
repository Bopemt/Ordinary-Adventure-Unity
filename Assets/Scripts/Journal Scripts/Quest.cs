using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest : ScriptableObject
{
    public int myOrderNumber;
    public string myName;
    public float myMoney;
    public float myExperience;
    public string myDescription;
    public float myLevel;
    public InventoryItem myItem;

    public FloatValue playerMoney;
    public FloatValue playerExperience;

    public SignalCore questSignal;
}
