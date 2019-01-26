using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumericCodeData : MonoBehaviour
{
    public int[] codeArray;

    public bool CheckCode(int[] code)
    {
        if(code.Length != codeArray.Length)
        {
            return false;
        }

        for(int i=0;i<code.Length; i++)
        {
            if(code[i] != codeArray[i])
            {
                return false;
            }
        }

        return true;
    }
}
