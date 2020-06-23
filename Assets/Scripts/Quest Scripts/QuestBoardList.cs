using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Quest Board List", menuName = "Quests/Quest Board List")]
public class QuestBoardList : ScriptableObject
{
    public List<Quest> allQuests = new List<Quest>();
    public List<Quest> boardQuests = new List<Quest>();

    public void ResetQuestBoard()
    {
        boardQuests = allQuests;
    }
}
