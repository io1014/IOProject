using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTrhow : Weapon
{
    Damage[] damages; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (statsUpdate == true)
        {
            statsUpdate = false;

            SetStats();
        }



    }

    public override void DoLevelUp()
    {
        SetStats();
    }

    public void SetStats()
    {
        damages = GetComponentsInChildren<Damage>();
        for (int i = 0; i < damages.Length; i++)
        {
            damages[i].damageamout = stats[weaponLevel].damage;
        }
    }
}
