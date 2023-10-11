using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _item; // invenItem 프리팹을 저장
    [SerializeField] ItemType _filterType;
    // 문제
    // 좌클릭하면 아이템 데이터 랜덤 생성해서(linqMore 참고) 인벤토리에 추가하고 표현
    // orderCount 누르면 count의 내림차순, 오름차순 순서 정렬이 스위칭 되서 표현 -> 인벤토리에 있는 아이템이 재정렬
    // orderScale 똑같이 Scale의 내림차순, 오름차순 순서 정렬이 스위칭되며 인벤토리에 갱신되어 표시
    // filterType 누르면 _filterType와 같은 타입만 인벤토리에 표시 다시 누르면 전체 목록 표시
    

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // 아이템 데이터 하나 생성하고
            // 프리팹 만들어서 인벤토리에 추가
        }
    }
}
