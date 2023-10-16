using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ZoneWeapon : Weapon
{
    public Damage damage;

    float spawntime, SpawnCounter;
    void Start()
    {
    }
    void Update()
    {
        
    }

    void Setstats()
    {
        damage.damageamout = stats[weaponLevel].damage;
        spawntime = stats[weaponLevel].timeToAttack;
        SpawnCounter = 0;
    }
}
