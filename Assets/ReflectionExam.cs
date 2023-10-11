using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ReflectionExam : MonoBehaviour
{
    List<ItemParent> items = new List<ItemParent>();
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int i = Random.Range(0, 3); // 한문장짜리 블럭은 블럭 생략가능
            if (i == 0) items.Add(new Food());
            else if (i == 1) items.Add(new Gun());
            else items.Add(new Obstacle());
        }

        if(Input.GetMouseButtonDown(1))
        {
            foreach (var data in items)
                Debug.Log($"data type is : {data.GetType().Name}"); // 한문장짜리라서 블럭을 생략한경우 줄바꿈은 들여쓰기
        }

        if(Input.GetKeyDown(KeyCode.Space)) // 전체 목록을 검사해서 타입에 따른 메소드를 실행
        {
            foreach(var data in items)
            {
                if(data.GetType() == typeof(Food))
                {
                    (data as Food)?.Split(); // as는 해당 타입으로 형변환을 시도해서 되면 형변화하고 안되면 Null을 리턴
                }
                if(data.GetType() == typeof(Gun))
                {
                    (data as Gun)?.Reload();
                }
                if(data.GetType() == typeof(Obstacle)) 
                {
                    (data as Obstacle)?.Disassemble();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            foreach(var data in items)
            {
                FieldInfo[] infos = data.GetType().GetFields();
                foreach(var info in infos)
                {
                    if(info.Name != "Count")
                    {
                        info.SetValue(data, 15);
                        break;
                    }
                }
                data.ItemUse();
            }
        }

        // 문제1
        // 마우스 좌클릭을 여러번 해서 랜덤하게 Gun클래스의 객체 생성을 확인한다. 우클릭통해서 확인
        // Gun 클래스에 int  하나를 인자로 받아서 10을 곱하고 반환하는 함수를 하나 생성
        // z키를 누르면 랜덤하게 만든 클래스 중에서 Gun 타입에 있는 새로 만든 함수에 적절한 값을 넣어서 실행하고
        // 그 결과를 정수 변수에 받아서 출력한다.
        // methodinfo를 통해서 invoke로 실행할것

        if(Input.GetKeyDown(KeyCode.Z))
        {
            foreach(var data in items)
            {
                if(data.GetType() == typeof(Gun))
                {
                    MethodInfo[] infos = data.GetType().GetMethods();
                    foreach(var info in infos)
                    {
                        if(info.Name == "Exam")
                        {
                            int i = (int)info.Invoke(data, new object[] { 25});
                            Debug.Log($"출력 결과 값은 {i} 입니다.");
                        }
                    }
                }
            }
        }

    }
}

public abstract class ItemParent
{
    public int Count = 25;
    public abstract void ItemUse();
}
public class Food : ItemParent
{
    public int AddHP;
    public override void ItemUse() => Debug.Log($"빵을 먹습니다. HP를 {AddHP} 만큼 회복합니다.");
    public void Split() => Debug.Log("갯수를 절반으로 나눠서 보관합니다.");
}

public class Gun : ItemParent
{
    public int MagSize;
    public override void ItemUse() => Debug.Log($"총알을 발사합니다. {MagSize} 만큼 총알이 남았습니다.");
    public void Reload() => Debug.Log("총을 다시 장전합니다.");
    public int Exam(int i) => i * 10;
}

public class Obstacle : ItemParent
{
    public int Durability;
    public override void ItemUse() => Debug.Log($"장애물을 설치합니다. {Durability} 만큼의 내구도가 남았습니다.");
    public void Disassemble() => Debug.Log("장애물을 회수합니다.");
}
