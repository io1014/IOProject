using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LamdbaTest : MonoBehaviour
{
    [SerializeField] ItemType _filterType;
    List<ItemData> lstData = new List<ItemData>();
    int id = 0;
    Action myAction;
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ItemType type = (ItemType)UnityEngine.Random.Range(0,(int)ItemType.Max);
            ItemData data = new ItemData(id, $"ID:{id++}", type, UnityEngine.Random.Range(0.5f,2.5f), UnityEngine.Random.Range(1,100));
            lstData.Add(data);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myAction?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            myAction += () =>
            {
                var temp = from data in lstData
                           orderby data.Scale descending
                           select data;
                var tempLst = temp.ToList();
                Debug.Log($"���� �������� ū DATA�� {tempLst[0].Id}, {tempLst[0].Scale}, {tempLst[0].Name}");
            };
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            myAction += () =>
            {
                var temp = from data in lstData
                           orderby data.Count descending
                           select data;
                var tempList = temp.ToList();
                Debug.Log($"���� ī��Ʈ�� ū DATA�� {tempList[0].Id}, {tempList[0].Count}, {tempList[0].Name}");
            };
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            myAction += () =>
            {
                var temp = from data in lstData
                           where data.Type == _filterType
                           select data;
                foreach(var data in temp)
                {
                    Debug.Log($"���ͷ� ������ ���� Ÿ���� �����ʹ� {data.Id}, {data.Name}, {data.Type}");
                }
            };
        }
        // ���콺 ��Ŭ���ϸ� itemData ���� ����Ʈ�� ����ϴ�.
        // �����̽��ٸ� ������ ������ ����� �����մϴ�.
        // 1���� ������ itemData���� ���� ū �����ϰ��� �����ͼ� ����ϴ� ����� �����մϴ�. linq
        // 2���� ���� ū ī���� ���� ���� �����ͼ� ����ϴ� ����� �����մϴ�.
        // 3���� �ν����Ϳ��� ������ Ÿ���� �����ͼ� ����ϴ� ����� �����մϴ�.foreach�� ���
        //List<int> ints = new List<int>();
        //ints.Add(10);
        //ints.Add(20);
        //ints.Add(30);
        //ints.Take(1);
    }
}
