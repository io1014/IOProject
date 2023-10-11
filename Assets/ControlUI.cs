using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour
{
    [SerializeField] Text _hpText; // ���� HPǥ��
    [SerializeField] Text _equipText; // ���� ��� ǥ��
    [SerializeField] Text _popupText; // ������ �����ۿ� ���� �ٸ� ���� ǥ��

    ItemUse iu;
    int _hp = 0;

    void Start()
    {
        _hpText.text = $"HP : {_hp}"; // ���ڿ� ����ǥ�� ���
        _equipText.text = "�������� ��� �����ϴ�.";
        _popupText.text = "";
    }

    public void SetAddHP() // HP image�� Ŭ���Ǹ� ������ �Լ�
    {
        _popupText.text = "HP�� ȸ�� ��Ű�ðڽ��ϱ�?";
        iu = addHP;
    }

    public void SetEquipItem() // equip image�� Ŭ���Ǹ� ������ �Լ�
    {
        _popupText.text = "���ҵ带 �����Ͻðڽ��ϱ�?";
        iu = EquipItem;
    }

    void addHP() // HP�� ���������ִ� �Լ�
    {
        _hp += 10;
        _hpText.text = $"HP : {_hp}";
    }

    void EquipItem() // ���ҵ带 ����ϴ� �Լ�
    {
        _equipText.text = "������� : ���ҵ�";
    }

    public void OnButton()
    {
        if (iu != null) iu();
    }
}
public delegate void ItemUse();
