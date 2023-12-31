using System;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    [SerializeField] public Sprite icon;
    public List<WeaponStats> stats;
    public int weaponLevel;
    public bool statsUpdate;
    public void LevelUp()
    {
        if (weaponLevel < stats.Count - 1)
        {
            weaponLevel++;
            statsUpdate = true;
            DoLevelUp();

            if (weaponLevel >= stats.Count - 1)
            {
                PlayerController.instance.MaxLevel.Add(this);
                PlayerController.instance.assignedWeapon.Remove(this);
            }
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
