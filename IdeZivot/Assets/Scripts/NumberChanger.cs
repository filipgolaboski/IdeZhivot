using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class NumberChanged : UnityEvent<int, int> { }

public class NumberChanger : MonoBehaviour
{
    public int currentNumber;
    public int position;
    public Text text;
    public NumberChanged onNumberChanged;

    private void Awake()
    {
        text.text = currentNumber.ToString();
    }

    public void IncrementNumber()
    {
        currentNumber++;
        if (currentNumber > 9)
        {
            currentNumber = 0;
        }
        onNumberChanged.Invoke(currentNumber, position);
        text.text = currentNumber.ToString();
    }

    public void DecrementNumber()
    {
        currentNumber--;
        if(currentNumber < 0)
        {
            currentNumber = 9;
        }
        text.text = currentNumber.ToString();
        onNumberChanged.Invoke(currentNumber, position);
    }
}
