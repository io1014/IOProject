using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class LinqPractice : MonoBehaviour
{
    List<int> ints = new List<int>();
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int addValue = Random.Range(0, 1000);
            ints.Add(addValue);
        }

        if(Input.GetMouseButtonDown(1))
        {
            //// ���� ū ���� �˻��ؼ� ���
            //int result = int.MinValue;
            //foreach(var data in ints)
            //{
            //    if(result < data)
            //    {
            //        result = data;
            //    }
            //}
            //// result���� ���� ū int���� ���� ��
            foreach(var data in ints)
            {
                Debug.Log($"List in value : {data}");
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var results = from data in ints  // � �÷��ǿ��� �����͸� �������ΰ��� in�ڿ� ����
                                             // �� �����Ϳ�Ҹ� � �̸����� �����ΰ�. from �ڿ� ����
                                             // foreach���� �����ϸ� ����
                          orderby data descending // orderby ��ǥ���� ���͸� ����, ����
                                                  // ������ ���� �����͸� orderby �ڿ� ���� �ǵڿ� ���Ĺ��
                                                  // descending ��������, ascending ��������
                          where data % 2 == 0 // ���ǽ��� where �� �ڿ� �ۼ�
                          where data > 900 //������ �ۼ��ؼ� ���� ���͸��� ���� �� ����
                          select data; // ���͸��� �����Ϳ��� � �����͸� ���������� ������ ���ΰ�.

            foreach(var data in results)
            {
                Debug.Log($"ordered data : {data}");
            }
        }
    }
}
