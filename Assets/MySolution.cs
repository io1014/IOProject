using UnityEngine;

public class MySolution : MonoBehaviour
{
    [SerializeField] int addValue;
    [SerializeField] int subtractValue;
    [SerializeField] int mulipleValue;
    [SerializeField] int divideValue;

    // 1번 누르면 더하기
    // 2번 누르면 빼기
    // 3번 누르면 곱하기
    // 4번 누르면 나누기

    // 번호를 누른 횟수만큼 더하고 빼고 곱하고 나눠서
    // 결과값을 스페이스 바 누르면 한번에 계산하고 출력한다. 
    // 대리자를 써서 함수 실행을 한번만 해서 출력

    // ex addvalue를 5, subtractValue 3 넣고 1번을 다섯번, 2번을 두번 누른후 스페이스바를 눌르면 19출력
    int result = 0; // 연산중간결과를 담을 변수
    MyDelegate dele;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            dele += AddInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            dele += SubInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            dele += MulInt;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            dele += DivInt;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (dele != null) dele();
            Debug.Log($"최종 연산 결과는 {result} 입니다.");
            dele = null;
            result = 0;
        }
    }

    void AddInt() { result += addValue; }
    void SubInt() { result -= subtractValue; }
    void MulInt() { result *= mulipleValue; }
    void DivInt() { result /= divideValue; }
}

