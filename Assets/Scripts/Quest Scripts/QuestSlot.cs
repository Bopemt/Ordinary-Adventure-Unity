using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestSlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI questNameText;

    [Header("Variables from the quest")]
    public Quest thisQuest;
    public QuestManager thisManager;

    public void Setup(Quest newQuest, QuestManager newManager)
    {
        thisQuest = newQuest;
        thisManager = newManager;
        if (thisQuest)
        {
            questNameText.text = thisQuest.myOrderNumber.ToString() + ". " + thisQuest.myName;
        }
    }

    public void ClickedOn()
    {
        if (thisQuest)
        {
            thisManager.description.SetupDescriptionAndButton(thisQuest);
        }
    }
}
