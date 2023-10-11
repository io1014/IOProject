using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class LevelUpButton : MonoBehaviour
{
    [SerializeField] TMP_Text upgradeText, nameLevelText;
    [SerializeField] Image weaponIcon;
    public Weapon weapon;

    public void UpdateButton(Weapon theweapon)
    {
        upgradeText.text = theweapon.stats[theweapon.weaponLevel].upgradetext;
        weaponIcon.sprite = theweapon.icon;
        nameLevelText.text = theweapon.name + "-lv" + theweapon.weaponLevel;

        weapon = theweapon;
    }
    public void SelectUpgrade()
    {
        if (weapon != null)
        {
            weapon.LevelUp();

            UIController.Instance.LevelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
  