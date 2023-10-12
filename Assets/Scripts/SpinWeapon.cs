using UnityEngine;

public class SpinWeapon : Weapon
{
    float _rotateSpeed = 180;
    Damage[] damages;
    void Start()
    {
        SetStats();
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (_rotateSpeed * Time.deltaTime * stats[weaponLevel].speed));

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
