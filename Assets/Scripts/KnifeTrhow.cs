using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTrhow : Weapon
{
    public Damage damage;
    public KnifeMove KnifeMove;

    private float shotCounter;

    public float weaponRange;
    public LayerMask whatIsEnemy;

    void Start()
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
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            shotCounter = stats[weaponLevel].timeToAttack;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange * stats[weaponLevel].range, whatIsEnemy);
            if (enemies.Length > 0)
            {
                for (int i = 0; i < stats[weaponLevel].amount; i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0, enemies.Length)].transform.position;

                    Vector3 direction = targetPosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle -= 90;
                    KnifeMove.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    Instantiate(KnifeMove, KnifeMove.transform.position, KnifeMove.transform.rotation).gameObject.SetActive(true);
                }
            }
        }
    }
    public override void DoLevelUp()
    {
        SetStats();
    }
    public void SetStats()
    {
        damage.damageamout = stats[weaponLevel].damage;
        damage.lifeTime = stats[weaponLevel].duration;
        damage.transform.localScale = Vector3.one * stats[weaponLevel].range;
        shotCounter = 0f;
    }
}
