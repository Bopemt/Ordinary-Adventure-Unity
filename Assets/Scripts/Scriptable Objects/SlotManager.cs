using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField] protected GameObject blankSlot;
    [SerializeField] protected GameObject slotsPanel;
    [SerializeField] protected GameObject panelHolder;
    [SerializeField] protected GenericStateMachine playerState;
    private InventoryItem item;

    //[Header("Description & Use Stuff")]
    //public ItemValue currentItem;

    protected virtual void ClearSlots(GameObject slotPanel)
    {
        for (int i = 0; i < slotPanel.transform.childCount; i++)
        {
            Destroy(slotPanel.transform.GetChild(i).gameObject);
        }
    }
}
