using System.Collections.Generic;
using UnityEngine;
public class ExperienceController : MonoBehaviour
{
    public static ExperienceController instance;
    [SerializeField] Experience experience;
    int currentexperience;
    public List<int> expLevels;
    int currentLevel = 1, maxLevel = 20;
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
        UIController.Instance.levelupButtons[0].UpdateButton(PlayerController.instance.weapon);
    }
}
