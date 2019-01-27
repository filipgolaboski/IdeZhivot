using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsePlace : MonoBehaviour
{
    public InventoryItem neededItem;
    public UnityEvent onItemSuccess;
    public UnityEvent onItemFail;
    public bool consumesItem;

    public delegate void OnUsingPlace(UsePlace place);
    public OnUsingPlace onUsingPlace;

    public AudioSource audioSource;
    public AudioClip failClip;
    public AudioClip successClip;

    public bool UseItem(InventoryItem item)
    {
        bool result = item == neededItem;
        if (result) 
        {
            audioSource.clip = successClip;
            audioSource.Play();
            onItemSuccess.Invoke();
        } 
        else 
        {
            audioSource.clip = failClip;
            audioSource.Play();
            onItemFail.Invoke();
        }
        return result;
    }

    public void UsingPlace()
    {
        onUsingPlace?.Invoke(this);
    }
}
