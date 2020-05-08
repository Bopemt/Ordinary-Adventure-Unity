using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{
    public GameObject dialogBox;
    [HideInInspector]
    public TextMeshProUGUI dialogText;
    [HideInInspector]
    public TextMeshProUGUI dialogName;
    public string text;
    public string speakerName;

    private void Start()
    {
        dialogText = dialogBox.transform.Find("Dialog Text Box").GetComponent<TextMeshProUGUI>();
        dialogName = dialogBox.transform.Find("Name Box").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = text;
                dialogName.text = speakerName;
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
