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
                Debug.Log($"가장 스케일이 큰 DATA는 {tempLst[0].Id}, {tempLst[0].Scale}, {tempLst[0].Name}");
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
                Debug.Log($"가장 카운트가 큰 DATA는 {tempList[0].Id}, {tempList[0].Count}, {tempList[0].Name}");
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
                    Debug.Log($"필터로 추출한 같은 타입의 데이터는 {data.Id}, {data.Name}, {data.Type}");
                }
            };
        }
        // 마우스 우클릭하면 itemData 랜덤 리스트를 만듭니다.
        // 스페이스바를 누르면 장전된 명령을 수행합니다.
        // 1번을 누르면 itemData에서 가장 큰 스케일값을 가져와서 출력하는 명령을 장전합니다. linq
        // 2번은 가장 큰 카운터 값을 가져 가져와서 출력하는 명령을 장전합니다.
        // 3번은 인스펙터에서 지정한 타입을 가져와서 출력하는 명령을 장전합니다.foreach로 출력
        //List<int> ints = new List<int>();
        //ints.Add(10);
        //ints.Add(20);
        //ints.Add(30);
        //ints.Take(1);
    }
}
