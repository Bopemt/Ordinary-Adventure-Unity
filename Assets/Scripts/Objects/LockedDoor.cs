using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door
{
    [SerializeField] private BoolValue storedValue;
    [SerializeField] private InventoryItem requiredKey;
    [SerializeField] private DoorValue doorValue;
    
    void Start()
    {
        isOpened = storedValue.value;
        if (isOpened)
        {
            Open();
        }
    }

    public override void Open()
    {
        base.Open();
        storedValue.value = true;
    }

    protected override void Update()
    {
        base.Update();
        CheckKey();
    }

    private void CheckKey()
    {
        if (playerInRange)
        {
            requiredKey.usable = true;
            doorValue.value = this;
        }
        else
        {
            requiredKey.usable = false;
        }
    }
}
