using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemPicked : UnityEvent<InventoryItem> { }

public class PickableObject : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public ItemPicked onItemPicked;
    bool alreadyAdded = false;

    public void PickItem()
    {
        if (!alreadyAdded)
        {
            onItemPicked.Invoke(inventoryItem);
            Destroy(gameObject);
        }
    }
}
