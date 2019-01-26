using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UsePlace : MonoBehaviour
{
    public InventoryItem neededItem;
    public InventoryData inventoryData;
    public UnityEvent onItemSuccess;
    public UnityEvent onItemFail;

    public void UseItem()
    {
        if (inventoryData.currentSelectedItem.name.Equals(neededItem.name) && inventoryData.currentSelectedItem.canBeUsed)
        {
            Debug.Log("Item:" + inventoryData.name);
            onItemSuccess.Invoke();
        }
        else
        {
            Debug.Log("Item Failed:" + inventoryData.name);
            onItemFail.Invoke();
        }
    }
}
