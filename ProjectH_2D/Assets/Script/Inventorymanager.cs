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

    public Toggle EnableRemove;

    public InventoryitemController[] InVentoryItems;

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
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("Removeitem").GetComponent<Button>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            if(EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
                
            
        }
    }

    public void EnableItemsRemove()
    {
        if(EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("Removeitem").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("Removeitem").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InVentoryItems = ItemContent.GetComponentsInChildren<InventoryitemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InVentoryItems[i].AddItem(Items[i]);
        }
    }
}
