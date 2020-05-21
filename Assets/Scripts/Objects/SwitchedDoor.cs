using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchedDoor : Door
{
    public Switch doorSwitch;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        checkSwitch();
    }

    private void checkSwitch()
    {
        if (doorSwitch.isActive && !isOpened)
        {
            Open();
        }
    }
}
