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
        // 1�� ������ addvalue�� ����
        // 2�� ������ subvalue�� ��
        // 3�� ������ multiValue�� ����
        // 4�� ������ divideValue�� ����
        // �ϴ� ����� �Լ��� �����̽��ٸ� ������ ���޾Ƽ�  �����ϰ�
        // �� ����� ���, ���۰��� 0
        // ���ٽ��� �Ἥ ����

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
