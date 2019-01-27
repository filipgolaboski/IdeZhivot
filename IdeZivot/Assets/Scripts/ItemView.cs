using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    private const int movementDuration = 20;
    private const int fadeDuration = 10;
    public Image itemSprite;
    public GameObject selectedState;
    public Button selectionCtrl;
    private bool isSelected;
    private bool isEmpty = true;
    private Vector3 maxScale = Vector3.one * 1.5f;

    public void SetView(Sprite sprite, Vector3 spriteStartingPos, Action selectAction)
    {
        itemSprite.sprite = sprite;
        itemSprite.enabled = true;
        itemSprite.transform.position = spriteStartingPos;
        StartCoroutine(AcquireSprite());

        selectionCtrl.onClick.RemoveAllListeners();
        selectionCtrl.onClick.AddListener(selectAction.Invoke);
        selectionCtrl.onClick.AddListener(ToggleSelectedState);
        isEmpty = false;
    }

    private IEnumerator AcquireSprite()
    {
        Color color = itemSprite.color;
        for (float i = 1; i <= fadeDuration; i++)
        {
            float t = i / fadeDuration;
            color.a = Mathf.Lerp(0, 1, t);
            itemSprite.color = color;
            itemSprite.transform.localScale = Vector3.Lerp(Vector3.one, maxScale, t);
            yield return null;
        }

        Transform imageTF = itemSprite.transform;
        Vector2 startingPos = imageTF.localPosition;
        for (float i = 1; i <= movementDuration; i++)
        {
            float t = i / fadeDuration;
            imageTF.localPosition = Vector2.Lerp(startingPos, Vector2.zero, t);
            itemSprite.transform.localScale = Vector3.Lerp(maxScale, Vector3.one, t);
            yield return null;
        }
    }

    public void UseItem(Vector2 destination, Action endAnimAction)
    {
        StartCoroutine(UseSprite(destination, endAnimAction));
    }

    private IEnumerator UseSprite(Vector2 destination, Action endAnimAction)
    {
        Transform imageTF = itemSprite.transform;
        Vector2 startingPos = imageTF.position;
        for (float i = 1; i <= movementDuration; i++)
        {
            imageTF.position = Vector2.Lerp(startingPos, destination, i / movementDuration);
            yield return null;
        }

        Color color = itemSprite.color;
        for (float i = 1; i <= fadeDuration; i++)
        {
            color.a = Mathf.Lerp(1, 0, i / fadeDuration);
            itemSprite.color = color;
            yield return null;
        }

        endAnimAction?.Invoke();
    }

    public void ReturnItem()
    {
        itemSprite.transform.localPosition = Vector3.zero;
        Color color = itemSprite.color;
        color.a = 1;
        itemSprite.color = color;
        ResetSelectState();
    }

    public void ToggleSelectedState()
    {
        isSelected = !isSelected;
        selectedState.SetActive(isSelected);
    }

    public void ResetSelectState()
    {
        if (isSelected) {
            ToggleSelectedState();
        }
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
