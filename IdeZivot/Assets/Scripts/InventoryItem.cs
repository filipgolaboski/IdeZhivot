using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public Sprite inventoryImage;
    public bool canBeUsed;
    public bool canBeViewed;
    public InventoryItem itemToBeCombined;
}
