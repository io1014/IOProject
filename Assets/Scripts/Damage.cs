using UnityEngine;
public class Damage : MonoBehaviour
{
    private float damage;
    public float damageamout { get { return damage; } set { damage = value; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.GetComponent<MosnterMove>().TakeDamage(damage);
        }
    }
}
