using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[System.Serializable]
public class NotifyPointerEnter : UnityEvent<MazeMoveSpot> { }

public class MazeMoveSpot : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    public NotifyPointerEnter NotifyPointerEnter;
    public Vector2 pos;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount == 0)
            NotifyPointerEnter.Invoke(this);
    }
}
