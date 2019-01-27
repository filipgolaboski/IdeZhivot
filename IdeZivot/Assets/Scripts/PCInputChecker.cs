using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCInputChecker : MonoBehaviour
{
    string inputString;
    public string compareString;
    public PickableObject pickableObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(inputString.Equals(compareString))
            {
                pickableObject.PickItem();
            }
        }
    }

    public void OnTextChanged(string val)
    {
        inputString = val;
    }
}
