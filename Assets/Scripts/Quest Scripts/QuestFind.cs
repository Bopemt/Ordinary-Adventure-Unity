using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Find quest", menuName = "Quests/Find Quest")]
public class QuestFind : ScriptableObject
{
    InventoryItem itemOfSearching;

    public int requiredAmount;
}
