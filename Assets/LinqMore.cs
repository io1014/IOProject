using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class LinqMore : MonoBehaviour
{
    [SerializeField] float _FilterScale;
    [SerializeField] ItemType _FilterType;

    List<ItemData> InvenData = new List<ItemData>();
    int id = 0;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ItemType type = (ItemType)Random.Range(0, (int)ItemType.Max);
            ItemData data = new ItemData(id, $"ID:{id++}", type, Random.Range(0.5f,2.5f), Random.Range(1,200));
            InvenData.Add(data);
            Debug.Log($"name : {data.Name}, count : {data.Count}");
        }

        if(Input.GetMouseButtonDown(1)) // Count가 많은 순서대로 정렬해서 출력
        {
            var datas = from data in InvenData
                        orderby data.Count descending
                        where data.Type == _FilterType
                        select data;

            List<ItemData> newDatas = datas.ToList(); // 정렬바뀐 결과값을 toList()함수를 통해 List형식으로 변경가능

            foreach(var data in datas)
            {
                Debug.Log($"result in : {data.Count}");
            }
        }
    }
}

public class ItemData
{
    public int Id;
    public string Name;
    public ItemType Type;
    public float Scale;
    public int Count;
    public ItemData(int id, string name, ItemType type, float scale, int count)
    {
        Id = id; Name = name; Type = type; Scale= scale; Count = count;
    }
}

public enum ItemType
{
    Food,
    Weapon,
    Armor,
    Scroll,
    Potion,
    Max,
}