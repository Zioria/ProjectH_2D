using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            StartCoroutine(UnselectAfterDelay(0.1f)); 
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

    private IEnumerator UnselectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
