using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public float bigHandleFinal;
    public float smallHandleFinal;
    bool smallHandleFinish = false;
    bool bigHandleFinish = false;
    public void BigHandleRotation(float rotation)
    {
        float twelvePart = rotation / 30;
        float diff = bigHandleFinal - twelvePart;
        if (diff < 0.1f || diff > -0.1f) {
            if (smallHandleFinish)
            {
                PickableObject p = GetComponentInChildren<PickableObject>();
                if (p != null) {
                    p.PickItem();
                }
            }
            else
            {
                bigHandleFinish = true;
            }
        }
    }

    public void SmallHandleRotation(float rotation)
    {
        float twelvePart = rotation / 30;
        float diff = bigHandleFinal - twelvePart;
        if (diff < 0.1f || diff > -0.1f)
        {
            if (bigHandleFinish)
            {
                PickableObject p = GetComponentInChildren<PickableObject>();
                if (p != null) { p.PickItem(); }
            }
            else
            {
                smallHandleFinish = true;
            }
        }
    }

}
