using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDescision : MonoBehaviour
{
    public Button vmro;
    public Button sdsm;
    public Button eu;

    public void PickVmro()
    {
        sdsm.gameObject.SetActive(false);
        eu.gameObject.SetActive(false);
    }

    public void PickSdsm()
    {
        vmro.gameObject.SetActive(false);
        eu.gameObject.SetActive(false);
    }

    public void PickEu()
    {
        sdsm.gameObject.SetActive(false);
        vmro.gameObject.SetActive(false);
    }
}
