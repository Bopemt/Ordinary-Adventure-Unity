using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBoxController : MonoBehaviour
{
    [Header("Dialogue Box Settings")]
    [SerializeField] private GameObject dialogObject;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI dialogName;
    [SerializeField] private bool dialogActive = false;

    [Header("Dialogue Box Strings")]
    [SerializeField] private StringValue stringText;
    [SerializeField] private StringValue stringName;

    public void ActivateDialog()
    {
        dialogActive = !dialogActive;
        if (dialogActive)
        {
            SetDialog();
        }
        else
        {
            DeactivateDialog();
        }
    }

    public void SetDialog()
    {
        dialogObject.SetActive(true);
        dialogText.text = stringText.value;
        dialogName.text = stringName.value;
    }

    public void DeactivateDialog()
    {
        dialogObject.SetActive(false);
    }
}
