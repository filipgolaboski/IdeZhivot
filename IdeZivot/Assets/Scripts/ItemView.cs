using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public Image itemSprite;
    public Button selectionCtrl;

    public void SetView(Sprite sprite, Action selectAction)
    {
        itemSprite.sprite = sprite;
        itemSprite.enabled = true;
        selectionCtrl.onClick.AddListener(selectAction.Invoke);
    }
}
