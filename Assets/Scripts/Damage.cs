using UnityEngine;

public class Damage : MonoBehaviour
{
    private float damage;

    public float damageamout { get { return damage; } set { damage = value; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            collision.GetComponent<MosnterMove>().TakeDamage(damage);
        }
        
    }
}
