using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New kill quest", menuName = "Quests/Kill Quest")]
public class QuestKill : Quest
{
    public override void CheckQuest()
    {
        if (isActive)
        {
            currentAmount++;
            base.CheckQuest();
        }
    }
}
