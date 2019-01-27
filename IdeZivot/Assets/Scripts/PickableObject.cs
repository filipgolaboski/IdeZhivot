﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemPicked : UnityEvent<InventoryItem, Vector2> { }

public class PickableObject : MonoBehaviour
{
    public InventoryItem inventoryItem;
    public ItemPicked onItemPicked;
    public AudioSource audioSource;
    public AudioClip collectClip;

    public void PickItem()
    {
        onItemPicked.Invoke(inventoryItem, transform.position);
        audioSource.clip = collectClip;
        audioSource.Play();
        Destroy(gameObject);
    }
}
