using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneView : MonoBehaviour
{
    public bool displayInventory = true;

    private PickableObject[] pickableObjects;
    private UsePlace[] usablePlaces;

    public delegate void OnPickUpItem(InventoryItem item, Vector2 itemPos);
    public OnPickUpItem onPickUpItem;
    public delegate void OnUsePlace(UsePlace usePlace);
    public OnUsePlace onUsePlace;

    void Start()
    {
        pickableObjects = GetComponentsInChildren<PickableObject>(true);
        foreach (var pickable in pickableObjects)
        {
            pickable.onItemPicked.AddListener(PickUpItem);
        }

        usablePlaces = GetComponentsInChildren<UsePlace>(true);
        foreach (var place in usablePlaces)
        {
            place.onUsingPlace = UsePlace;
        }
    }

    private void PickUpItem(InventoryItem item, Vector2 itemPos)
    {
        onPickUpItem?.Invoke(item, itemPos);
    }

    private void UsePlace(UsePlace place)
    {
        onUsePlace?.Invoke(place);
    }

    public void ShowScene()
    {
        gameObject.SetActive(true);
    }

    public void HideScene()
    {
        gameObject.SetActive(false);
    }
}
