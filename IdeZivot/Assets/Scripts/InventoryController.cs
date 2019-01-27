using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Transform inventoryViewsContainer;
    public SceneController sceneController;
    public CloseItemView closeItemView;
    public SceneView closeViewScene;
    public Image wrong;
    private ItemView[] itemViews;
    private SceneView currentScene;
    private InventoryItem currentItem;
    private InventoryItem closeItem;
    private ItemView selectedView;

    void Start()
    {
        itemViews = inventoryViewsContainer.GetComponentsInChildren<ItemView>();
    }

    private void ToggleInventory(bool state)
    {
        inventoryViewsContainer.gameObject.SetActive(state);
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
        ToggleInventory(newScene.displayInventory);
        ResetViewSelectedStates();
        ClearSelectedItem();
        currentScene = newScene;
    }

    private void ResetViewSelectedStates()
    {
        foreach (var view in itemViews)
        {
            view.ResetSelectState();
        }
    }

    public void PickUpItem(InventoryItem item, Vector2 itemPos)
    {
        foreach (var view in itemViews)
        {
            if (view.IsEmpty())
            {
                view.SetView(item.inventoryImage, itemPos, delegate { SelectItem(item, view); });
                break;
            }
        }
    }

    public void SelectItem(InventoryItem item, ItemView view)
    {
        if (item.canBeViewed)
        {
            if (item == closeItem) 
            {
                closeItem = null;
                sceneController.UnloadScene();
            } 
            else
            {
                if (selectedView != null)
                {
                    selectedView.ResetSelectState();
                }
                
                closeItemView.SetView(item.inventoryImage, item.itemToBeCombined,
                    (usePlace) => { usePlace.UseItem(currentItem); });

                if (closeItem == null)
                {
                    sceneController.LoadScene(closeViewScene);
                } 
                else if (selectedView != null)
                {
                    selectedView.ResetSelectState();
                    currentItem = null;
                }
                closeItem = item;
                selectedView = view;
            }
        }
        else
        {
            if (currentItem == item)
            {
                ClearSelectedItem();
            } else
            {
                if (selectedView != null)
                {
                    selectedView.ResetSelectState();
                }

                currentItem = item;
                selectedView = view;
            }
        }

        // if (item == currentItem && !item.canBeViewed)
        // {
        //     ClearSelectedItem();
        // }
        // else if (closeItem == item)
        // {
        //     sceneController.UnloadScene();
        //     closeItem = null;
        // }
        // else 
        // {
        //     if (selectedView != null) {
        //         selectedView.ToggleSelectedState();
        //     }

        //     if (item.canBeViewed)
        //     {
        //         closeItemView.SetView(item.inventoryImage, item.itemToBeCombined,
        //             (usePlace) => { usePlace.UseItem(currentItem); });

        //         if (closeItem == null) {
        //             sceneController.LoadScene(closeViewScene);
        //         }
        //         closeItem = item;

        //     }
        //     currentItem = item;
        //     selectedView = view;
        // }
    }

    private void ClearSelectedItem()
    {
        currentItem = null;
        selectedView = null;
    }

    public void ClearCloseItem()
    {
        closeItem = null;
    }

    public void UseItem(UsePlace usePlace)
    {
        if (currentItem != null)
        {
            if (usePlace.neededItem == currentItem) {
                selectedView.UseItem(usePlace.transform.position, delegate { UseItemOnPlace(usePlace); });
            } 
            else
            {
                StartCoroutine(ShowX());
                selectedView.ResetSelectState();
                ClearSelectedItem();
            }
        }
    }

    IEnumerator ShowX() {
        wrong.gameObject.SetActive(true);
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        wrong.transform.position = pos;
        yield return new WaitForSeconds(0.5f);
        wrong.gameObject.SetActive(false);
    }


    private void UseItemOnPlace(UsePlace usePlace)
    {
        bool isUsed = usePlace.UseItem(currentItem);
        if (isUsed)
        {
            closeItemView.HideView();
            if (usePlace.consumesItem) 
            {
                selectedView.ClearView();
            } else {
                selectedView.ReturnItem();
            }
        }
        ClearSelectedItem();
    }
}
