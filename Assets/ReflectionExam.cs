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
            int i = Random.Range(0, 3); // �ѹ���¥�� ���� �� ��������
            if (i == 0) items.Add(new Food());
            else if (i == 1) items.Add(new Gun());
            else items.Add(new Obstacle());
        }

        if(Input.GetMouseButtonDown(1))
        {
            foreach (var data in items)
                Debug.Log($"data type is : {data.GetType().Name}"); // �ѹ���¥���� ���� �����Ѱ�� �ٹٲ��� �鿩����
        }

        if(Input.GetKeyDown(KeyCode.Space)) // ��ü ����� �˻��ؼ� Ÿ�Կ� ���� �޼ҵ带 ����
        {
            foreach(var data in items)
            {
                if(data.GetType() == typeof(Food))
                {
                    (data as Food)?.Split(); // as�� �ش� Ÿ������ ����ȯ�� �õ��ؼ� �Ǹ� ����ȭ�ϰ� �ȵǸ� Null�� ����
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

        // ����1
        // ���콺 ��Ŭ���� ������ �ؼ� �����ϰ� GunŬ������ ��ü ������ Ȯ���Ѵ�. ��Ŭ�����ؼ� Ȯ��
        // Gun Ŭ������ int  �ϳ��� ���ڷ� �޾Ƽ� 10�� ���ϰ� ��ȯ�ϴ� �Լ��� �ϳ� ����
        // zŰ�� ������ �����ϰ� ���� Ŭ���� �߿��� Gun Ÿ�Կ� �ִ� ���� ���� �Լ��� ������ ���� �־ �����ϰ�
        // �� ����� ���� ������ �޾Ƽ� ����Ѵ�.
        // methodinfo�� ���ؼ� invoke�� �����Ұ�

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
                            Debug.Log($"��� ��� ���� {i} �Դϴ�.");
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
    public override void ItemUse() => Debug.Log($"���� �Խ��ϴ�. HP�� {AddHP} ��ŭ ȸ���մϴ�.");
    public void Split() => Debug.Log("������ �������� ������ �����մϴ�.");
}

public class Gun : ItemParent
{
    public int MagSize;
    public override void ItemUse() => Debug.Log($"�Ѿ��� �߻��մϴ�. {MagSize} ��ŭ �Ѿ��� ���ҽ��ϴ�.");
    public void Reload() => Debug.Log("���� �ٽ� �����մϴ�.");
    public int Exam(int i) => i * 10;
}

public class Obstacle : ItemParent
{
    public int Durability;
    public override void ItemUse() => Debug.Log($"��ֹ��� ��ġ�մϴ�. {Durability} ��ŭ�� �������� ���ҽ��ϴ�.");
    public void Disassemble() => Debug.Log("��ֹ��� ȸ���մϴ�.");
}
