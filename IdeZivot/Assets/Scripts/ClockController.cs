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
        float normalTwelvePart = 12 - twelvePart;
        float diff = bigHandleFinal - normalTwelvePart;
        if ((diff < 0.2f && diff > 0)  || (diff > -0.2f && diff < 0) || 12f - normalTwelvePart < 0.2f) {
            if (smallHandleFinish)
            {
                Finish();
            }
            else
            {
                bigHandleFinish = true;
            }
        }
        else
        {
            bigHandleFinish = false;
        }
    }

    public void SmallHandleRotation(float rotation)
    {
        float twelvePart = rotation / 30;
        float normalTwelvePart = 12 - twelvePart;
        float diff = smallHandleFinal - normalTwelvePart;
        if ((diff < 0.2f && diff > 0) || (diff > -0.2f && diff < 0) || 12f - bigHandleFinal < 0.2f)
        {
            if (bigHandleFinish)
            {
                Finish();
            }
            else
            {
                smallHandleFinish = true;
            }
        }
        else
        {
            smallHandleFinish = false;
        }
    }

    public void Finish()
    {
        //do animation here  
        PickableObject p = GetComponentInChildren<PickableObject>();
        if (p != null) { p.PickItem(); }
    }

}
