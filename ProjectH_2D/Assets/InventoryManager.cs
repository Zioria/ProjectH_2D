using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public void addItem(Item item)
    {
        for (int i = 0; i< inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();
            
        }
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {

    }
}
