using System;
using UnityEditor;
using UnityEngine;

public class lamdbaPractice : MonoBehaviour
{
    Action myAction;
    void Start()
    {
        Action action1;
        action1 = () => Debug.Log("람다 식을 선언해서 할당 합니다."); // 단항으로 된 식읠 경우 식 람다 라고 함
        action1();

        action1 = () =>
        {
            Debug.Log("여러줄을 넣을 수 ");
            Debug.Log("있습니다.");
        }; // <- 블럭 뒤에는 반드시 문장 마침표가 필요  문 람다 라고 함

        Action<int> action2; //int 형 인자를 하나 받는 대리자
        action2 = (x) => Debug.Log($"입력값은 {x}"); // 소괄호 안에 인자를 받을 수 있음, 형식은 생략가능
        action2(5);

        action2 = x => Debug.Log($"인자가 1개일 경우 소괄호는 생략할 수 있음{x}");
        action2(1);
        action2 = x =>
        {
            Debug.Log("문 람다일 경우에도");
            Debug.Log($"동일하게 인자가 1개는 소괄호를 생략할 수 있음 {x}");
        };

        action2(3);

        Func<string> func1;
        func1 = () => "식 람다의 경우 return 키워드를 생략할 수 있음";

        Debug.Log($"람다 실행 결과는 {func1()}");

        func1 = () =>
        {
            return "문 람다의 경우 return 을 생략할 수 없음";
        };

        Debug.Log($"문 람다를 실행한 결과는 {func1()} 입니다.");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            myAction = () => Debug.Log("1번을 눌렀습니다."); //람다식
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            myAction?.Invoke(); // ? 는 변수의 null 체크 
            //if (myAction != null) myAction(); 와 동일
        }
    }
}
