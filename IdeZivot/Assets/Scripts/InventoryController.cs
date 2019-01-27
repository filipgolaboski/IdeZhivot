﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Transform inventoryViewsContainer;
    public InventoryData inventoryData;
    private ItemView[] itemViews;
    private SceneView currentScene;
    private int currentItemView = 0;
    private InventoryItem currentItem;

    void Start()
    {
        itemViews = inventoryViewsContainer.GetComponentsInChildren<ItemView>();
    }

    public void ListenForPickUpsOnScene(SceneView newScene)
    {
        if (currentScene != null)
        {
            currentScene.onPickUpItem = null;
            currentScene.onUsePlace = null;
        }
        newScene.onPickUpItem = PickUpItem;
        newScene.onUsePlace = UseItem;
        currentScene = newScene;
    }

    public void PickUpItem(InventoryItem item)
    {
        inventoryData.AddData(item);
        itemViews[currentItemView++].SetView(item.inventoryImage, delegate { SelectItem(item); });
    }

    public void SelectItem(InventoryItem item)
    {
        foreach (var view in itemViews)
        {
            if (view.IsEmpty())
            {
                view.SetView(item.inventoryImage, delegate { SelectItem(item, view); });
                break;
            }
        }
    }

    public void SelectItem(InventoryItem item, ItemView view)
    {
        if (item == currentItem)
        {
            ClearSelectedItem();
        }
        else 
        {
            currentItem = item;
            selectedView = view;
        }
    }

    private void ClearSelectedItem()
    {
        currentItem = null;
        selectedView = null;
    }

    public void UseItem(UsePlace usePlace)
    {
        usePlace.UseItem(currentItem);
    }
}
