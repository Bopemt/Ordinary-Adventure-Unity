using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    [SerializeField] private SignalCore updateInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.AddItem(thisItem);
            updateInventory.Raise();
            Destroy(this.gameObject);
        }
    }
}
