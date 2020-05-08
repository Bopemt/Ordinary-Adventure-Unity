using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchedDoor : Door
{
    public Switch doorSwitch;
    
    // Update is called once per frame
    void Update()
    {
        if(doorSwitch.isActive && !isOpened)
        {
            Open();
        }
    }
}
