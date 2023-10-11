using UnityEngine;

public class DelgatePractice : MonoBehaviour
{
    MyDelegate _md;
    myStringDelegate _msd;
    private void Start()
    {
        //_md = func;
        //_msd = strFunc;
        //_md();
        //_md = func2;
        //_md(); // func2가 실행
        //_md = strFunc; // 시그니쳐가 맞지 않아서 해당 변수에 메소드를 할당할수 없음 

        _md = func;
        _md += func2; //더하기 연산자
        _md();

        _md -= func;
        _md();
    }
    void func2() 
    {
        Debug.Log("func2가 실행되었습니다.");
    }
    void func()
    {
        Debug.Log("func가 실행되었습니다.");
    }
    void Update()
    {
        
    }
    string strFunc()
    {
        return "";
    }
}

public delegate void MyDelegate();
// class, enum, struct처럼 형식으로 선언한다.
// 접근제한자, delegate 키워드, 반환값, 식별자(이름), 소괄호(인자)로 선언한다.
// 반환값과 인자를 메소드의 시그니쳐라고 하고
// 시그니쳐가 같은 메소드만 대리자변수에 할당할 수 있다.
// 대리자 변수는 인자로 전달하거나 전달 받을수 있다.
public delegate string myStringDelegate();

