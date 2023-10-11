using UnityEngine;
using System;
using System.Reflection;

public class ReflectionPractice : MonoBehaviour
{
    void Start()
    {
        string str = "일반 문자열개체";
        Type type = str.GetType();
        Debug.Log($"형식 메타 정보 {type.Name}, {type.Namespace}");

        ParentClass pc = new ParentClass();
        Type pcType = pc.GetType();

        Debug.Log($"parentClass의 형식 메타 정보 {pcType.Name}, {pcType.Namespace}");

        MethodInfo[] datas = type.GetMethods();
        foreach(var data in datas)
        {
            //Debug.Log($"data {data.Name}, {data.ReturnParameter}, {data.GetParameters()[0]}");
        }

        ChildClass cc = new ChildClass();
        Type ccType = cc.GetType();
        FieldInfo[] fields = ccType.GetFields();
        foreach(var field in fields)
        {
            Debug.Log($"멤버 변수 이름 {field.Name}, 변수 타입 {field.FieldType.Name}");
            if(field.Name == "parentInt")
            {
                field.SetValue(cc, 10);
                Debug.Log($"ParentInt의 값은 {cc.parentInt} 입니다.");
            }
        }


        MethodInfo[] ccMethods = ccType.GetMethods();
        foreach(var data in ccMethods)
        {
            if(data.Name == "ParentFunc")
            {
                int j = (int)data.Invoke(cc, new object[] { 5});
                Debug.Log($"ParentFunc 메소드의 출력값은 {j} 입니다.");
            }
        }

        Type pType = typeof(ParentClass);
        Debug.Log($"parent 형식의 이름 : {pType.Name} , {pType.GetMethods()[0].Name}");
    }
}

public class ParentClass
{
    public int parentInt;
    protected int parentProtectInt;
    private int parentPraivateInt;
    public int ParentFunc(int i)
    {
        parentInt = i;
        Debug.Log($"세팅된 정수값은 : {parentInt} 입니다.");
        return parentInt + 5;
    }
}

public class ChildClass : ParentClass
{
    public int childPublicInt;
    private int childPrivateInd;
}