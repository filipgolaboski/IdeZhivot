using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseItemView : MonoBehaviour
{
    public Image itemSprite;
    public UsePlace usePlace;

    public void SetView(Sprite sprite, InventoryItem itemToBeUsed, Action<UsePlace> usingItemAction)
    {
        gameObject.SetActive(true);
        itemSprite.sprite = sprite;
        usePlace.neededItem = itemToBeUsed;
        usePlace.onUsingPlace = usingItemAction.Invoke;
    }

    public void HideView()
    {
        gameObject.SetActive(false);
    }
}
