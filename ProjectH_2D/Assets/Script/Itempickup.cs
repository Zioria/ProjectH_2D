using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itempickup : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        Inventorymanager.Instance.Add(Item);
        Destroy(gameObject);
    }

   
    private void OnMouseDown()
    {
        Pickup();
    }
}
