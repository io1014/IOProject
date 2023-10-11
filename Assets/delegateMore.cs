using System;
using UnityEngine;

public class delegateMore : MonoBehaviour
{
    Action myAction; // ��ȯ���� ���� // ���ڸ� �ִ� �븮�� ������ ��ǥ�̸�
    Action<int> oneIntAction;
    Action<int, int> twoIntAction;

    Func<string> myFunc; // ��ȯ���� �ִ� �޼ҵ��� �븮��, ������ ���׸����ڴ� �ݵ�� ��ȯ�����̾�� ��
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
// ��ȯ���� ���ڸ� �ñ״��ķ� �븮�� ������ �����ϰ� ���