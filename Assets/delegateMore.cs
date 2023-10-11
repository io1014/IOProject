using System;
using UnityEngine;

public class delegateMore : MonoBehaviour
{
    Action myAction; // 반환값이 없는 // 인자만 있는 대리자 형식의 대표이름
    Action<int> oneIntAction;
    Action<int, int> twoIntAction;

    Func<string> myFunc; // 반환값이 있는 메소드의 대리자, 마지막 제네릭인자는 반드시 반환형식이어야 함
    Func<int,bool> myBoolFunc;

    Func<int, int> myIntDouble;

    private void Start()
    {
        myAction = func;
        oneIntAction = oneIntFunc;
        twoIntAction = twoIntFunc;

        myFunc = retStrFunc;
        myBoolFunc = retBoolFunc;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myIntDouble += retIntFunc;
        }
        if(Input.GetMouseButtonDown(1))
        {
            int result = 1;
            foreach(Func<int, int> data in myIntDouble.GetInvocationList())
            {
                result =  data(result);
            }
            Debug.Log($"result is : {result}");
        }
    }
    int retIntFunc(int i)
    {
        return i + i;
    }

    void func() { }
    void oneIntFunc(int i) { }
    void twoIntFunc(int i, int j) { }

    string retStrFunc() { return ""; }
    bool retBoolFunc(int i) { return false; }

}

public delegate void MyNewDele();
// 반환값과 인자를 시그니쳐로 대리자 형식을 선언하고 사용