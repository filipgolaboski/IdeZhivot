using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVController : MonoBehaviour
{
    public GameObject[] tvChannels;
    public GameObject offState;
    public GameObject tuner;
    bool powerOn = false;
    int currentChannel = 0;

    private void Awake()
    {
        // TVStateChanged();
    }

    public void ChangeChannel()
    {
        if (powerOn)
        {
            int previousChannel = currentChannel;
            currentChannel++;
            if (currentChannel >= tvChannels.Length)
            {
                currentChannel = 0;
                previousChannel = tvChannels.Length - 1;
            }

            tvChannels[previousChannel].gameObject.SetActive(false);
            tvChannels[currentChannel].gameObject.SetActive(true);

            tuner.transform.Rotate(Vector3.forward, 30);
        }
    }

    public void TVStateChanged()
    {
        powerOn = !powerOn;
        tvChannels[currentChannel].gameObject.SetActive(powerOn);
        offState.gameObject.SetActive(!powerOn);
    }
}