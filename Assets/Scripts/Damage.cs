using System.Collections.Generic;
using UnityEngine;
public class Damage : MonoBehaviour
{
    public float damage = 1;
    public float lifeTime = 100;

    public bool destroyParent;

    public bool damageOverTime;
    public float timeBetweenDamage;

    float damageCounter;

    private List<MosnterMove> enemiesInRange = new List<MosnterMove>();
    public float damageamout { get { return damage; } set { damage = value; } }

    private void Update()
    {
       lifeTime -= Time.deltaTime;

        if(lifeTime <=0)
        {
            Destroy(gameObject);

            if(destroyParent)
            {
                Destroy(transform.parent.gameObject);
            }
        }
        if(damageOverTime ==true)
        {
            damageCounter -= Time.deltaTime;

            if(damageCounter <=0)
            {
                damageCounter = timeBetweenDamage;

                for(int i = 0; i < enemiesInRange.Count; i++)
                {
                    if (enemiesInRange[i] != null)
                    {
                        enemiesInRange[i].TakeDamage(damageamout);
                    }
                    else
                    {
                        enemiesInRange.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageOverTime == false)
        {
            if (collision.CompareTag("Monster"))
            {
                collision.GetComponent<MosnterMove>().TakeDamage(damage);
            }
        }else
        {
            if(collision.tag == "Monster")
            {
                enemiesInRange.Add(collision.GetComponent<MosnterMove>());  
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(damageOverTime == true)
        {
            if(collision.tag == "Monster")
            {
                enemiesInRange.Remove(collision.GetComponent<MosnterMove>());
            }
        }
    }
}
