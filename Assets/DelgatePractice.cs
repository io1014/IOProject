using UnityEngine;

public class DelgatePractice : MonoBehaviour
{
    MyDelegate _md;
    myStringDelegate _msd;
    private void Start()
    {
        //_md = func;
        //_msd = strFunc;
        //_md();
        //_md = func2;
        //_md(); // func2�� ����
        //_md = strFunc; // �ñ״��İ� ���� �ʾƼ� �ش� ������ �޼ҵ带 �Ҵ��Ҽ� ���� 

        _md = func;
        _md += func2; //���ϱ� ������
        _md();

        _md -= func;
        _md();
    }
    void func2() 
    {
        Debug.Log("func2�� ����Ǿ����ϴ�.");
    }
    void func()
    {
        Debug.Log("func�� ����Ǿ����ϴ�.");
    }
    void Update()
    {
        
    }
    string strFunc()
    {
        return "";
    }
}

public delegate void MyDelegate();
// class, enum, structó�� �������� �����Ѵ�.
// ����������, delegate Ű����, ��ȯ��, �ĺ���(�̸�), �Ұ�ȣ(����)�� �����Ѵ�.
// ��ȯ���� ���ڸ� �޼ҵ��� �ñ״��Ķ�� �ϰ�
// �ñ״��İ� ���� �޼ҵ常 �븮�ں����� �Ҵ��� �� �ִ�.
// �븮�� ������ ���ڷ� �����ϰų� ���� ������ �ִ�.
public delegate string myStringDelegate();

