using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    public static PlayerStatController instance;
    public List<PlayerStatValue> moveSpeed, health, pickupRange, maxWeapons;
    public int moveSpeedLevelCount, healthLevelCount, pickupRangeLevelCount;
    public int moveSpeedLevel, healthLevel, pickupRangeLevel, maxWeaponsLevel;


    private void Awake() => instance = this;
    void Start()
    {
        for (int i = moveSpeed.Count - 1; i < moveSpeedLevelCount; i++)
        {
            moveSpeed.Add(new PlayerStatValue(moveSpeed[i].cost + moveSpeed[1].cost, moveSpeed[i].value + (moveSpeed[1].value - moveSpeed[0].value)));
        }
        for (int i = health.Count - 1; i < healthLevelCount; i++)
        {
            health.Add(new PlayerStatValue(health[i].cost + health[1].cost, health[i].value + (health[1].value - health[0].value)));
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (UIController.Instance.LevelUpPanel.activeSelf == true)
        {
            UpdateDisplay();
        }

    }
    public void UpdateDisplay()
    {


    }

    public void Purchasehealth()
    {
        
        healthLevel++;
        PlayerHealthController.Instance.currenthealth += 5;
        UpdateDisplay();

        PlayerHealthController.Instance.maxhealth = health[healthLevel].value;
    }
    public void Purchasespeed()
    {
        UpdateDisplay();

        PlayerController.instance.speed = moveSpeed[moveSpeedLevel].value;
    }
    public void PurchasepickupRange()
    {
        UpdateDisplay();

        PlayerController.instance.range = pickupRange[pickupRangeLevel].value;
    }
    public void PurchasemaxWeapons()
    {
        UpdateDisplay();

    }
}
[Serializable]
public class PlayerStatValue
{
    public int cost;
    public float value;

    public PlayerStatValue(int newCost, float newValue)
    {
        cost = newCost;
        value = newValue;
    }
}


