using System;
using UnityEngine;

public class DelegateFinal : MonoBehaviour
{
    [SerializeField] int addValue;
    [SerializeField] int subtractValue;
    [SerializeField] int multiplyValue;
    [SerializeField] int divideValue;

    Func<int, int> calcFunc;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            calcFunc += addInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            calcFunc += subtractInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            calcFunc += multiplyInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            calcFunc += divideInt;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(calcFunc != null)
            {
                int result = 0;
                foreach(Func<int, int> data in calcFunc.GetInvocationList())
                {
                    result = data(result);
                }
                Debug.Log($"result is : {result}");
            }
            calcFunc = null;
        }
    }
    int addInt(int i) { return i + addValue; }
    int subtractInt(int i) { return i - subtractValue; }
    int multiplyInt(int i) { return i * multiplyValue; }
    int divideInt(int i) { return i / divideValue; }
}
