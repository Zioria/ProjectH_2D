using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    

    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Item item;
   

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Started");

        image.raycastTarget = false;
        parentAfterDrag = transform.parent;

        // Debug the parent assignment
        Debug.Log("Parent After Drag Set To: " + parentAfterDrag.name);

        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        // Verify that parentAfterDrag is still assigned
        if (parentAfterDrag != null)
        {
            transform.SetParent(parentAfterDrag);
            Debug.Log("Parent Reset to: " + parentAfterDrag.name);
        }
        else
        {
            Debug.LogWarning("parentAfterDrag is null!");
        }
    }
}
