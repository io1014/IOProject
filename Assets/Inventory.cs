using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _item; // invenItem �������� ����
    [SerializeField] ItemType _filterType;
    // ����
    // ��Ŭ���ϸ� ������ ������ ���� �����ؼ�(linqMore ����) �κ��丮�� �߰��ϰ� ǥ��
    // orderCount ������ count�� ��������, �������� ���� ������ ����Ī �Ǽ� ǥ�� -> �κ��丮�� �ִ� �������� ������
    // orderScale �Ȱ��� Scale�� ��������, �������� ���� ������ ����Ī�Ǹ� �κ��丮�� ���ŵǾ� ǥ��
    // filterType ������ _filterType�� ���� Ÿ�Ը� �κ��丮�� ǥ�� �ٽ� ������ ��ü ��� ǥ��
    

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // ������ ������ �ϳ� �����ϰ�
            // ������ ���� �κ��丮�� �߰�
        }
    }
}
