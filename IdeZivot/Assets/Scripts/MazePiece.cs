using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class SelectMaizePiece : UnityEvent<MazePiece> { }

public class MazePiece : MonoBehaviour,IPointerDownHandler
{
    public Vector2 pos;

    public SelectMaizePiece selectedMaizePiece;

    public void OnPointerDown(PointerEventData eventData)
    {
        selectedMaizePiece.Invoke(this);
    }
}
