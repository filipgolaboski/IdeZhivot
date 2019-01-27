using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public Image itemSprite;
    public GameObject selectedState;
    public Button selectionCtrl;
    private bool isSelected;
    private bool isEmpty = true;

    public void SetView(Sprite sprite, Action selectAction)
    {
        itemSprite.sprite = sprite;
        itemSprite.enabled = true;
        selectionCtrl.onClick.RemoveAllListeners();
        selectionCtrl.onClick.AddListener(selectAction.Invoke);
        selectionCtrl.onClick.AddListener(ToggleSelectedState);
        isEmpty = false;
    }

    public void ToggleSelectedState()
    {
        isSelected = !isSelected;
        selectedState.SetActive(isSelected);
    }

    public void ClearView()
    {
        isEmpty = true;
        itemSprite.enabled = false;
        isSelected = false;
        selectedState.SetActive(isSelected);
        selectionCtrl.onClick.RemoveAllListeners();
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }
}
