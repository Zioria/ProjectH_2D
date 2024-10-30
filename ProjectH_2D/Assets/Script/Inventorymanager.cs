using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventorymanager : MonoBehaviour
{ 
    public static Inventorymanager Instance;
    public List<Item> Items = new List<Item>();
    
    public Transform ItemContent;
    public GameObject InventoryItem;

    public void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }
    
    public void ListItems()
    {
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }

    //public void EnableItemsRemove()
   // {
        //if(EnableRemove.isOn)
        //{
           // foreach (Transform item in ItemContent)
            //{
              //  item.Find("RemoveButton").gameObject.SetActive(true);
           // }
       // }
       // else
       // {
           // foreach (Transform item in ItemContent)
           // {
            //    item.Find("RemoveButton").gameObject.SetActive(false);
           // }
      //  }
   // }
}
