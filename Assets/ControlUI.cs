using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour
{
    [SerializeField] Text _hpText; // 현재 HP표시
    [SerializeField] Text _equipText; // 현재 장비 표시
    [SerializeField] Text _popupText; // 선태한 아이템에 따라 다른 내용 표시

    ItemUse iu;
    int _hp = 0;

    void Start()
    {
        _hpText.text = $"HP : {_hp}"; // 문자열 보간표현 방식
        _equipText.text = "착용중인 장비가 없습니다.";
        _popupText.text = "";
    }

    public void SetAddHP() // HP image가 클릭되면 실행할 함수
    {
        _popupText.text = "HP를 회복 시키시겠습니까?";
        iu = addHP;
    }

    public void SetEquipItem() // equip image가 클릭되면 실행할 함수
    {
        _popupText.text = "숏소드를 착용하시겠습니까?";
        iu = EquipItem;
    }

    void addHP() // HP를 증가시켜주는 함수
    {
        _hp += 10;
        _hpText.text = $"HP : {_hp}";
    }

    void EquipItem() // 숏소드를 장비하는 함수
    {
        _equipText.text = "착용장비 : 숏소드";
    }

    public void OnButton()
    {
        if (iu != null) iu();
    }
}
public delegate void ItemUse();
