using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAXE2 : Weapon
{
    public Damage damage;

    float throwCounter;

    void Start()
    {
        SetStats();
        
    }
    void Update()
    {
        if(statsUpdate ==true)
        {
            statsUpdate = false;

            SetStats();
        }
        throwCounter -= Time.deltaTime;
        if(throwCounter <=0)
        {
            throwCounter = stats[weaponLevel].timeToAttack;

            for(int i = 0; i < stats[weaponLevel].amount; i++)
            {
                Instantiate(damage,damage.transform.position,damage.transform.rotation).gameObject.SetActive(true);
            }
            SFXManager.instance.PlaySFXPitched(1);
        }
        
    }

    void SetStats()
    {
        damage.damageamout = stats[weaponLevel].damage;
        damage.lifeTime = stats[weaponLevel].duration;

        damage.transform.localScale =Vector3.one * stats[weaponLevel].range;

        throwCounter = 0f;
    }
}
