using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

public class SolutionInven : MonoBehaviour
{
    [SerializeField] GameObject _item; // item 프리팹
    [SerializeField] Transform _content; // 스크롤뷰의 content 트랜스폼
    [SerializeField] ItemType _filterType;
    
    List<ItemData> items = new List<ItemData>();
    List<GameObject> prefabs = new List<GameObject>(); // item 프리팹을 생성하면 List에 추가

    int id = 0;

    Action countButton; //카운트 정렬버튼
    Action scaleButton; //스케일 정렬버튼
    Action typeButton; // 타입 정렬버튼

    void FilterType() // 타입 필터 조건을 실행할때 
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
    void ShowAll(List<ItemData> lst) // 필터가 적용안되서 모든 프리팹 요소들이 표현되는 함수
    {
        for (int i = 0; i < lst.Count; i++)
        {
            prefabs[i].GetComponent<ItemBase>().Init(lst[i]); // gameobject.setActice(true)에 의해 켜짐
        }
    }

    void NoFilterType() // 타입 필터를 없는 조건을 실행할때
    {
        ShowAll(items);
        typeButton = FilterType;
    }
    void ScaleAsc() // 스케일 오름차순 조건
    {
        var temp = from data in items
                   orderby data.Scale ascending
                   select data;
        items = temp.ToList();
        scaleButton = ScaleDesc;
    }
    void ScaleDesc() // 스케일 내림차순 조건
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

    void AllDisable() // 필터가 적용되기전에 모든 프리팹 요소들을 끄는 함수
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
            temp.GetComponent<ItemBase>().Init(data); // 인벤토리에 배치
            prefabs.Add(temp);
        }
    }
}
