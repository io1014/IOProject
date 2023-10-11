using System;
using UnityEditor;
using UnityEngine;

public class lamdbaPractice : MonoBehaviour
{
    Action myAction;
    void Start()
    {
        Action action1;
        action1 = () => Debug.Log("���� ���� �����ؼ� �Ҵ� �մϴ�."); // �������� �� ���� ��� �� ���� ��� ��
        action1();

        action1 = () =>
        {
            Debug.Log("�������� ���� �� ");
            Debug.Log("�ֽ��ϴ�.");
        }; // <- �� �ڿ��� �ݵ�� ���� ��ħǥ�� �ʿ�  �� ���� ��� ��

        Action<int> action2; //int �� ���ڸ� �ϳ� �޴� �븮��
        action2 = (x) => Debug.Log($"�Է°��� {x}"); // �Ұ�ȣ �ȿ� ���ڸ� ���� �� ����, ������ ��������
        action2(5);

        action2 = x => Debug.Log($"���ڰ� 1���� ��� �Ұ�ȣ�� ������ �� ����{x}");
        action2(1);
        action2 = x =>
        {
            Debug.Log("�� ������ ��쿡��");
            Debug.Log($"�����ϰ� ���ڰ� 1���� �Ұ�ȣ�� ������ �� ���� {x}");
        };

        action2(3);

        Func<string> func1;
        func1 = () => "�� ������ ��� return Ű���带 ������ �� ����";

        Debug.Log($"���� ���� ����� {func1()}");

        func1 = () =>
        {
            return "�� ������ ��� return �� ������ �� ����";
        };

        Debug.Log($"�� ���ٸ� ������ ����� {func1()} �Դϴ�.");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            myAction = () => Debug.Log("1���� �������ϴ�."); //���ٽ�
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            myAction?.Invoke(); // ? �� ������ null üũ 
            //if (myAction != null) myAction(); �� ����
        }
    }
}
