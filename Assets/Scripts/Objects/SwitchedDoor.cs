using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchedDoor : Door
{
    public Switch doorSwitch;

    private void Start()
    {
        checkSwitch();
    }

    protected override void Update()
    {
        base.Update();
        checkSwitch();
    }

    public void checkSwitch()
    {
        if (doorSwitch.isActive && !isOpened)
        {
            Open();
        }
    }
}
