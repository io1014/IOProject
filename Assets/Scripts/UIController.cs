using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField] Slider expslider;
    [SerializeField] TMP_Text expLevel;
    [SerializeField]public LevelUpButton[] levelupButtons;
    [SerializeField]public GameObject LevelUpPanel;
    [SerializeField] Weapon[] Weapons;
    [SerializeField] TMP_Text coinText;
    [SerializeField] PlayerStatUpgradeDisplay  moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickupRangeUpgradeDisplay, maxWeaponsUpgradeDisplay;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoins()
    {
        coinText.text = ": " + CoinController.instance.Coin;
    }
    public void UpdateExperience(int currentExp, int levelexp, int currentlevel)
    {
        expslider.maxValue = levelexp;
        expslider.value = currentExp;

        expLevel.text = "Level :" + currentlevel;
    }
}
