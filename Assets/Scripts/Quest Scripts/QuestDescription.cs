using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestDescription : Description
{
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Image weaponImage;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private QuestValue selectedQuest;
    [SerializeField] private Button addQuestButton;

    protected override void OnEnable()
    {
        base.OnEnable();
        selectedQuest.value = null;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectedQuest.value = null;
    }

    public override void SetupDescriptionAndButton(Quest newQuest)
    {
        if (newQuest.inJournal)
        {
            if (newQuest.isActive)
            {
                useButton.interactable = false;
                addQuestButton.interactable = false;
                useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Active mission";
            }
            else
            {
                useButton.interactable = true;
                addQuestButton.interactable = false;
                useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Set Active";
            }
        }
        else
        {
            useButton.interactable = false;
            addQuestButton.interactable = true;
        }
        selectedQuest.value = newQuest;
        descriptionText.text = newQuest.myDescription;
        nameText.text = newQuest.myName;
        experienceText.text = "Exp: " + newQuest.myExperience;
        coinText.text = "Coins: " + newQuest.myMoney;
        if (newQuest.myItem)
        {
            weaponImage.sprite = newQuest.myItem.mySprite;
            weaponImage.enabled = true;
            weaponText.text = newQuest.myItem.myName;
        }
        else
        {
            weaponText.text = "";
            weaponImage.enabled = false;
        }
    }

    public override void ClearDescriptionAndButton()
    {
        base.ClearDescriptionAndButton();
        selectedQuest.value = null;
        useButton.interactable = false;
        addQuestButton.interactable = false;
        useButton.GetComponentInChildren<TextMeshProUGUI>().text = "Set Active";
        experienceText.text = "";
        coinText.text = "";
        weaponText.text = "";
        weaponImage.enabled = false;
    }
}
