using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAXE : Weapon
{
   [SerializeField] Damage damage;

    float throwCount;
    // Start is called before the first frame update
    void Start()
    {
        UIController.Instance.levelupButtons[1].UpdateButton(this);

    }
    public override void DoLevelUp()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (statsUpdate == true)
        {
            statsUpdate = false;

            //SetStats();
        }

        throwCount -= Time.deltaTime;
        if (throwCount <= 0)
        {
            throwCount = stats[weaponLevel].timeToAttack;

            for (int i = 0; i < stats[weaponLevel].amount; i++)
            {
                Damage obj = Instantiate(damage, damage.transform.position, damage.transform.rotation);//.gameObject.SetActive(true);
                obj.gameObject.SetActive(true);
                SetStats(obj);
            }
        }
      

    }
    public void SetStats(Damage dmg)
    {
        {
            dmg.damageamout = stats[weaponLevel].damage;

            dmg.transform.localScale = Vector3.one * stats[weaponLevel].range;
            
            //damage.damageamout = stats[weaponLevel].damage;
            //Debug.Log($"{damage.damageamout}");
        }

    }
    
}
