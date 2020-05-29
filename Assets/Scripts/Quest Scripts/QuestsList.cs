using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Quests List", menuName = "Quests/Quests List")]
public class QuestsList : ScriptableObject
{
    public List<Quest> list = new List<Quest>();
}
