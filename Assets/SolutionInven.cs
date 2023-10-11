using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

public class SolutionInven : MonoBehaviour
{
    [SerializeField] GameObject _item; // item ������
    [SerializeField] Transform _content; // ��ũ�Ѻ��� content Ʈ������
    [SerializeField] ItemType _filterType;
    
    List<ItemData> items = new List<ItemData>();
    List<GameObject> prefabs = new List<GameObject>(); // item �������� �����ϸ� List�� �߰�

    int id = 0;

    Action countButton; //ī��Ʈ ���Ĺ�ư
    Action scaleButton; //������ ���Ĺ�ư
    Action typeButton; // Ÿ�� ���Ĺ�ư

    void FilterType() // Ÿ�� ���� ������ �����Ҷ� 
    {
        AllDisable();
        var temp = from data in items
                   where data.Type == _filterType
                   select data;
        var tempList = temp.ToList();
        ShowAll(tempList);
        //for(int i = 0; i < tempList.Count;i++)
        //{
        //    prefabs[i].GetComponent<ItemBase>().Init(tempList[i]);
        //}
        typeButton = NoFilterType;
    }
    void ShowAll(List<ItemData> lst) // ���Ͱ� ����ȵǼ� ��� ������ ��ҵ��� ǥ���Ǵ� �Լ�
    {
        for (int i = 0; i < lst.Count; i++)
        {
            prefabs[i].GetComponent<ItemBase>().Init(lst[i]); // gameobject.setActice(true)�� ���� ����
        }
    }

    void NoFilterType() // Ÿ�� ���͸� ���� ������ �����Ҷ�
    {
        ShowAll(items);
        typeButton = FilterType;
    }
    void ScaleAsc() // ������ �������� ����
    {
        var temp = from data in items
                   orderby data.Scale ascending
                   select data;
        items = temp.ToList();
        scaleButton = ScaleDesc;
    }
    void ScaleDesc() // ������ �������� ����
    {
        var temp = from data in items
                   orderby data.Scale descending
                   select data;
        items = temp.ToList();
        scaleButton = ScaleAsc;
    }
    void CountAsc()
    {
        var temp = from data in items
                   orderby data.Count ascending
                   select data;
        items = temp.ToList();
        countButton = CountDesc;
    }
    void CountDesc()
    {
        var temp = from data in items
                   orderby data.Count descending
                   select data;
        items = temp.ToList();
        countButton = CountAsc;
    }

    public void CountButton() { countButton(); ShowAll(items); }
    public void ScaleButton() { scaleButton(); ShowAll(items); }
    public void TypeButton() { typeButton(); }

    void AllDisable() // ���Ͱ� ����Ǳ����� ��� ������ ��ҵ��� ���� �Լ�
    {
        foreach(var data in prefabs)
        {
            data.SetActive(false); 
        }
    }

    void Start()
    {
        countButton = CountAsc;
        scaleButton = ScaleAsc;
        typeButton = FilterType;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ItemType type = (ItemType)UnityEngine.Random.Range(0, (int)ItemType.Max);
            ItemData data = new ItemData(id, $"ID:{id++}", type, UnityEngine.Random.Range(0.5f,2.5f), UnityEngine.Random.Range(1,100));
            items.Add(data);
            GameObject temp = Instantiate(_item, _content);
            temp.GetComponent<ItemBase>().Init(data); // �κ��丮�� ��ġ
            prefabs.Add(temp);
        }
    }
}
