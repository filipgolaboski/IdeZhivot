using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumericCodeSystem : MonoBehaviour
{
    public NumericCodeData numericCodeData;
    int[] inputArray;

    public UnityEvent onCodeSuccess;
    public UnityEvent onCodeFail;

    private void Awake()
    {
        inputArray = new int[numericCodeData.codeArray.Length];
    }


    public void CheckCode()
    {
        if (numericCodeData.CheckCode(inputArray))
        {
            
            onCodeSuccess.Invoke();
        }
        else
        {
            onCodeFail.Invoke();
        }
    }

    public void SetCode(int[] newInputArray)
    {
        if(newInputArray.Length == inputArray.Length)
        {
            inputArray = newInputArray;
        }
        
    }

    public void SetCodeAt(int val, int position)
    {
        if(position < inputArray.Length)
        {
            inputArray[position] = val;
        }
        CheckCode();
    }

}
