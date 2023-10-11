using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> stats;
    public int weaponLevel;

    public bool statsUpdate;

    [SerializeField] public Sprite icon;
   
    public void LevelUp()
    {
        if(weaponLevel < stats.Count -1)
        {
            weaponLevel++;
            statsUpdate = true;
            DoLevelUp();
        }
    }
    public virtual void DoLevelUp()
    {

    }
}
[Serializable]

public class WeaponStats
{
    public float speed, damage, range, timeToAttack, amount, duration;
    public string upgradetext; 
}
