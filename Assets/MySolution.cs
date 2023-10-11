using UnityEngine;

public class MySolution : MonoBehaviour
{
    [SerializeField] int addValue;
    [SerializeField] int subtractValue;
    [SerializeField] int mulipleValue;
    [SerializeField] int divideValue;

    // 1�� ������ ���ϱ�
    // 2�� ������ ����
    // 3�� ������ ���ϱ�
    // 4�� ������ ������

    // ��ȣ�� ���� Ƚ����ŭ ���ϰ� ���� ���ϰ� ������
    // ������� �����̽� �� ������ �ѹ��� ����ϰ� ����Ѵ�. 
    // �븮�ڸ� �Ἥ �Լ� ������ �ѹ��� �ؼ� ���

    // ex addvalue�� 5, subtractValue 3 �ְ� 1���� �ټ���, 2���� �ι� ������ �����̽��ٸ� ������ 19���
    int result = 0; // �����߰������ ���� ����
    MyDelegate dele;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            dele += AddInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            dele += SubInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            dele += MulInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            dele += DivInt;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (dele != null) dele();
            Debug.Log($"���� ���� ����� {result} �Դϴ�.");
            dele = null;
            result = 0;
        }
    }

    void AddInt() { result += addValue; }
    void SubInt() { result -= subtractValue; }
    void MulInt() { result *= mulipleValue; }
    void DivInt() { result /= divideValue; }
}

