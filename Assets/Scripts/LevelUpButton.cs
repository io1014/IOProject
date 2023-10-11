using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LevelUpButton : MonoBehaviour
{
    [SerializeField] TMP_Text upgradeText, nameLevelText;
    [SerializeField] Image weaponIcon;
    public Weapon weapon;
    public void UpdateButton(Weapon theweapon)
    {
        if (theweapon.gameObject.activeSelf == true)
        {
            upgradeText.text = theweapon.stats[theweapon.weaponLevel].upgradetext;
            weaponIcon.sprite = theweapon.icon;
            nameLevelText.text = theweapon.name + "-lv" + theweapon.weaponLevel;
        }
        else
        {
            upgradeText.text = "Unlock " + theweapon.name;
            weaponIcon.sprite = theweapon.icon;
            nameLevelText.text = theweapon.name;

        }
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
