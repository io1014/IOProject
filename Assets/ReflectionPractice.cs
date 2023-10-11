using UnityEngine;
using System;
using System.Reflection;

public class ReflectionPractice : MonoBehaviour
{
    void Start()
    {
        string str = "�Ϲ� ���ڿ���ü";
        Type type = str.GetType();
        Debug.Log($"���� ��Ÿ ���� {type.Name}, {type.Namespace}");

        ParentClass pc = new ParentClass();
        Type pcType = pc.GetType();

        Debug.Log($"parentClass�� ���� ��Ÿ ���� {pcType.Name}, {pcType.Namespace}");

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
            Debug.Log($"��� ���� �̸� {field.Name}, ���� Ÿ�� {field.FieldType.Name}");
            if(field.Name == "parentInt")
            {
                field.SetValue(cc, 10);
                Debug.Log($"ParentInt�� ���� {cc.parentInt} �Դϴ�.");
            }
        }


        MethodInfo[] ccMethods = ccType.GetMethods();
        foreach(var data in ccMethods)
        {
            if(data.Name == "ParentFunc")
            {
                int j = (int)data.Invoke(cc, new object[] { 5});
                Debug.Log($"ParentFunc �޼ҵ��� ��°��� {j} �Դϴ�.");
            }
        }

        Type pType = typeof(ParentClass);
        Debug.Log($"parent ������ �̸� : {pType.Name} , {pType.GetMethods()[0].Name}");
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
        Debug.Log($"���õ� �������� : {parentInt} �Դϴ�.");
        return parentInt + 5;
    }
}

public class ChildClass : ParentClass
{
    public int childPublicInt;
    private int childPrivateInd;
}