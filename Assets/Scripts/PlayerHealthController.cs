using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;
    public float currenthealth, maxhealth = 100;
    [SerializeField]
    Slider healthSlider;
   
    //public List<PlayerStatValue> moveSpeed, health, pickupRange, maxWeapons;
    //public int moveSpeedLevelCount, healthLevelCount, pickupRangeLevelCount;

    //public int moveSpeedLevel, healthLevel, pickupRangeLevel, maxWeaponsLevel;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currenthealth = maxhealth;
        healthSlider.maxValue = maxhealth;
        healthSlider.value= currenthealth;

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.maxValue = maxhealth;
        healthSlider.value = currenthealth;



    }

    public void UpdateBtn()
    {
        if (UIController.Instance.LevelUpPanel.activeSelf == true)
        {

        }
    }

    public void TakeDamage(float damage)
    {
        currenthealth -= damage;

        if(currenthealth <= 0)
        {
            gameObject.SetActive(false);
        }
        healthSlider.value = currenthealth;
    }

  

}
