using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemToPickup;



    public void PickupItem(int id)
    {
        bool result = inventoryManager.addItem(itemToPickup[id]);
        if(result == true)
        {
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("ITEM IS NOT ADDED");
        }
    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelcetedItem();
        if (receivedItem != null)
        {
            Debug.Log("Received item: " + receivedItem);
        }
        else
        {
            Debug.Log("No Item received!");
        }
    }

    public void UseGetSelectedItem()
    {
        Item receivedItem = inventoryManager.UseSelcetedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("Used item: " + receivedItem);
        }
        else
        {
            Debug.Log("No Item used!");
        }
    }
}
