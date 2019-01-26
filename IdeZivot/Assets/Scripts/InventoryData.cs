using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventoryData")]
public class InventoryData : ScriptableObject
{
    public InventoryItem currentSelectedItem;
    public InventoryItem[] items;
}
