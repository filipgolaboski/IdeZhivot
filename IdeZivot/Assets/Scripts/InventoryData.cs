using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventoryData")]
public class InventoryData : ScriptableObject
{
    public List<InventoryItem> items;

    public void AddData(InventoryItem inventoryItem)
    {
        items.Add(inventoryItem);
    }
}
