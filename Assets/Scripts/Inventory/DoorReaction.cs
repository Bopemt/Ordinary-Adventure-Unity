using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReaction : MonoBehaviour
{
    [SerializeField] private DoorValue door;

    public void Use()
    {
        door.value.Open();
        door.value.context.Raise();
    }
}
