using System;
using UnityEngine;

public class LambdaExam : MonoBehaviour
{
    [SerializeField] int addValue;
    [SerializeField] int subValue;
    [SerializeField] int multiValue;
    [SerializeField] int divideValue;

    Func<int, int> addedFunc;

    void Update()
    {
        // 1번 누르면 addvalue를 더함
        // 2번 누르면 subvalue를 뺌
        // 3번 누르면 multiValue를 곱함
        // 4번 누르면 divideValue를 나눔
        // 하는 기능의 함수를 스페이스바를 누르면 연달아서  수행하고
        // 그 결과를 출력, 시작값은 0
        // 람다식을 써서 구현

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            addedFunc += x => x + addValue;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(addedFunc != null)
            {
                int result = 0;
                foreach(Func<int, int> data in addedFunc.GetInvocationList())
                {
                    result = data(result);
                }
                Debug.Log($"result value is : {result}");
            }
            addedFunc = null;
        }

    }
}
