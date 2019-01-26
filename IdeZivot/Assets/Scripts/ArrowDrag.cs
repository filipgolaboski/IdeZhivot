using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class HandlePosition : UnityEvent<float> { }

public class ArrowDrag : MonoBehaviour, IPointerDownHandler
{
    bool act = false;
    public HandlePosition handlePosition;

    private void Update()
    {
        if (act)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.LookAt(mouse, Vector3.forward);
                Vector3 eulers = transform.rotation.eulerAngles;
                eulers.z = 0;
                transform.Rotate(eulers);
            }

            if(Input.GetMouseButtonUp(0))
            {
                handlePosition.Invoke(transform.rotation.eulerAngles.z);
                act = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        act = true;
    }
}
