using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
    public float bigHandleFinal;
    public float smallHandleFinal;
    bool smallHandleFinish = false;
    bool bigHandleFinish = false;
    public PickableObject passport;
    public Image[] frames;

    public void BigHandleRotation(float rotation)
    {
        float twelvePart = rotation / 30;
        float normalTwelvePart = 12 - twelvePart;
        float diff = bigHandleFinal - normalTwelvePart;
        if ((diff < 0.2f && diff > 0)  || (diff > -0.2f && diff < 0) || 12f - normalTwelvePart < 0.2f) {
            if (smallHandleFinish)
            {
                StartCoroutine(FinishAnim());
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
                StartCoroutine(FinishAnim());
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
        passport.PickItem();
    }


    IEnumerator FinishAnim()
    {
        for(int i = 1; i < frames.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            frames[i - 1].gameObject.SetActive(false);
            frames[i].gameObject.SetActive(true);
        }
        Finish();
    }
}
