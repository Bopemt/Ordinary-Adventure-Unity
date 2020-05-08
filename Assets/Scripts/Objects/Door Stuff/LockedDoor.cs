using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door
{
    public BoolValue storedValue;
    
    void Start()
    {
        isOpened = storedValue.RuntimeValue;
        if (isOpened)
        {
            Open();
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && !isOpened)
        {
            if (playerInRange)
            {
                if (playerInventory.numberOfKeys > 0)
                {
                    playerInventory.numberOfKeys--;
                    Open();
                    storedValue.RuntimeValue = true;
                    context.Raise();
                }
            }
        }
    }
}
