using UnityEngine;

public class MosnterMove : MonoBehaviour
{
    Rigidbody2D rb;
    float speed =2;
    Transform Target;
    float damage = 5;
    float hitTIme = 1f;
    float hitCounter;
    float health = 10;
    [SerializeField] int exp;
    [SerializeField] int coin;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Target = FindObjectOfType<PlayerController>().transform; 
    }
    void Update()
    {
        rb.velocity = (Target.position - transform.position).normalized * speed;
        if(hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.CompareTag("Player") &&  hitCounter <= 0)
        {
            PlayerHealthController.Instance.TakeDamage(damage);
            //collision.collider.GetComponent<NewPlayerHealthController>().TakeDamage(damage);
            hitCounter = hitTIme;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            Destroy(gameObject);
            ExperienceController.instance.SpawnExp(transform.position, exp);
            CoinController.instance.SpawnCoin(transform.position,coin);
        }
        DamageNumberControll._instance.SpawnDamage(damage, transform.position);

    }
}
