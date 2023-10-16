using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SworldWeapon : Weapon
{
    public Damage damage;

    float attackCounter, direction;
    private void Start()
    {
        SetStats();
    }

    void Update()
    {
        if (statsUpdate == true)
        {
            statsUpdate = false;

            SetStats();
        }
        attackCounter -= Time.deltaTime;
        if (attackCounter <= 0)
        {
            attackCounter = stats[weaponLevel].timeToAttack;

            direction = Input.GetAxisRaw("Horizontal");

            if (direction != 0)
            {
                if (direction > 0)
                {
                    damage.transform.rotation = Quaternion.identity;
                }
                else
                {
                    damage.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }
            }
            Instantiate(damage, damage.transform.position, damage.transform.rotation, transform).gameObject.SetActive(true);

            for (int i = 1; i < stats[weaponLevel].amount; i++)
            {
                float rot = (360f / stats[weaponLevel].amount) * i;

                Instantiate(damage, damage.transform.position, Quaternion.Euler(0f, 0f, damage.transform.rotation.eulerAngles.z + rot), transform).gameObject.SetActive(true);
            }

        }
       
    }
    void SetStats()
    {
        damage.damageamout = stats[weaponLevel].damage;
        damage.lifeTime = stats[weaponLevel].duration;
        damage.transform.localScale = Vector3.one * stats[weaponLevel].range;
        attackCounter = 0f;

    }
}
