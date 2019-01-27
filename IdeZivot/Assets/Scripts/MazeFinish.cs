using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class NotifyFinishEnter : UnityEvent<MazeFinish> { }

public class MazeFinish : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    public NotifyFinishEnter NotifyPointerEnter;
    public Vector2 pos;
    public bool finished;
    public MazePiece mazePiece;


    public void OnPointerEnter(PointerEventData eventData)
    {
        NotifyPointerEnter.Invoke(this);
    }
}
