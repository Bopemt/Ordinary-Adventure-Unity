using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : SlotManager
{
    [SerializeField] private GameObject boardPanelHolder;
    [SerializeField] private QuestsList questList;
    [SerializeField] private QuestBoardList questBoardList;
    [SerializeField] private QuestValue selectedQuest;
    [SerializeField] private QuestValue activeQuest;
    [SerializeField] private GameObject boardSlotsPanel;
    [SerializeField] private GameObject questCompleteNotification;

    [Header("Description & Use Stuff")]
    public QuestDescription description;

    public void Update()
    {
        if (Input.GetButtonDown("Quest Journal") && (playerState.myState == GenericState.idle || playerState.myState == GenericState.walk || playerState.myState == GenericState.journal))
        {
            if (panelHolder.gameObject.activeInHierarchy)
            {
                CloseJournal();
            }
            else
            {
                OpenJournal();
            }
        }
        else if (Input.GetButtonUp("Pause") && playerState.myState == GenericState.journal)
        {
            CloseJournal();
        }
    }

    public void OpenJournal()
    {
        panelHolder.gameObject.SetActive(true);
        playerState.myState = GenericState.journal;
        MakeSlots(questList.questList, blankSlot, slotsPanel);
        Time.timeScale = 0.000001f;
    }

    public void CloseJournal()
    {
        if (boardPanelHolder.gameObject.activeInHierarchy)
        {
            OpenQuestBoard();
        }
        panelHolder.gameObject.SetActive(false);
        playerState.myState = GenericState.idle;
        ClearSlots(slotsPanel);
        Time.timeScale = 1;
    }

    public void OpenQuestBoard()
    {
        if (boardPanelHolder.gameObject.activeInHierarchy)
        {
            boardPanelHolder.gameObject.SetActive(false);
            ClearSlots(boardSlotsPanel);
            CloseJournal();
        }
        else
        {
            boardPanelHolder.gameObject.SetActive(true);
            MakeSlots(questBoardList.boardQuests, blankSlot, boardSlotsPanel);
            OpenJournal();
        }
    }

    protected void MakeSlots(List<Quest> list, GameObject _blankSlot, GameObject slotPanel)
    {
        questList.questList.RemoveAll(q => q.isComplete);
        foreach (Quest item in list)
        {
            QuestSlot newSlot = Instantiate(_blankSlot, transform.position, transform.rotation, slotPanel.transform)
             .GetComponent<QuestSlot>();
            if (newSlot)
            {
                newSlot.Setup(item, this);
            }
        }
    }

    public void CreateQuestCompleteNotification()
    {
        GameObject completeNotification = Instantiate(questCompleteNotification, transform);
        Destroy(completeNotification, 1.1f);
        activeQuest.value = null;
    }

    public void UseButtonPressed()
    {
        if (activeQuest.value)
        {
            activeQuest.value.isActive = false;
        }
        activeQuest.value = selectedQuest.value;
        activeQuest.value.isActive = true;
        description.SetupDescriptionAndButton(activeQuest.value);
        ClearSlots(slotsPanel);
        MakeSlots(questList.questList, blankSlot, slotsPanel);
    }

    public void AddQuestButtonPressed()
    {
        selectedQuest.value.inJournal = true;
        questBoardList.boardQuests.Remove(selectedQuest.value);
        questList.questList.Add(selectedQuest.value);
        description.ClearDescriptionAndButton();
        ClearSlots(slotsPanel);
        ClearSlots(boardSlotsPanel);
        MakeSlots(questList.questList, blankSlot, slotsPanel);
        MakeSlots(questBoardList.boardQuests, blankSlot, boardSlotsPanel);
    }
}
