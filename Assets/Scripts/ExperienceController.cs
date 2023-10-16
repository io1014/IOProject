using System.Collections.Generic;
using UnityEngine;
public class ExperienceController : MonoBehaviour
{
    public static ExperienceController instance;
    [SerializeField] Experience experience;
    int currentexperience;
    public List<int> expLevels;
    int currentLevel = 1, maxLevel = 20;
    public List<Weapon> weaponsList;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        while (expLevels.Count < maxLevel)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.2f));
        }
    }
    public void GetExp(int Exp)
    {
        currentexperience += Exp;
        if (currentexperience >= expLevels[currentLevel])
        {
            currentexperience = 0;
            LevelUp();
        }
        UIController.Instance.UpdateExperience(currentexperience, expLevels[currentLevel], currentLevel);
    }
    public void SpawnExp(Vector3 pos, int expvalue)
    {
        Instantiate(experience, pos, Quaternion.identity).value = expvalue;
    }
    void LevelUp()
    {
        currentexperience -= expLevels[currentLevel];
        currentLevel++;
        if (currentLevel >= expLevels.Count)
        {
            currentLevel = expLevels.Count - 1;
        }
        UIController.Instance.LevelUpPanel.SetActive(true);
        Time.timeScale = 0f;

        weaponsList.Clear();
        List<Weapon> weapons = new List<Weapon>();
        weapons.AddRange(PlayerController.instance.assignedWeapon); //할당된 무기 리스트에 저장
        if (weapons.Count > 0)
        {
            int select = Random.Range(0, weapons.Count);
            weaponsList.Add(weapons[select]);
            weapons.RemoveAt(select);
        }
        if (PlayerController.instance.assignedWeapon.Count +PlayerController.instance.MaxLevel.Count < PlayerController.instance.maxWeapon)
        {
            weapons.AddRange(PlayerController.instance.unassignedWeapon);
        }

        for (int i = weaponsList.Count; i < 3; i++)
        {
            if(weapons.Count >0)
            {
                int select = Random.Range(0, weapons.Count);
                weaponsList.Add(weapons[select]);
                weapons.RemoveAt(select);
            }
        }
        for(int i = 0; i < weaponsList.Count; i++)
        {
            UIController.Instance.levelupButtons[i].UpdateButton(weaponsList[i]);
        }
        for (int i =0; i <UIController.Instance.levelupButtons.Length; i++)
        {
            if(i < weaponsList.Count)
            {
                UIController.Instance.levelupButtons[i].gameObject.SetActive(true);
            }
            else
            {
                UIController.Instance.levelupButtons[i].gameObject.SetActive(false);
            }
        }
    }

}
