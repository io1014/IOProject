using UnityEngine;

public class MosnterMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer SR;
    public float speed;
    Transform Target;
    float damage = 5;
    float hitTIme = 1f;
    float hitCounter;
    [SerializeField]float health;
    bool islive = true;
    Animator ani;
    [SerializeField] int exp;
    [SerializeField] int coin = 40;
    [SerializeField] float Droprate = 0.5f;
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Target = FindObjectOfType<PlayerController>().transform;
        SR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (!islive)
            return;
        rb.velocity = (Target.position - transform.position).normalized * speed;
        if(hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        if (!islive)
            return;
      SR.flipX = Target.position.x > rb.transform.position.x;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       if(collision.collider.CompareTag("Player") &&  hitCounter <= 0.2f)
        {
            PlayerHealthController.Instance.TakeDamage(damage);
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
            UIController.Instance.killcount = UIController.Instance.killcount + 1;


            if (Random.value <= Droprate) 
            {
                CoinController.instance.SpawnCoin(transform.position, coin);
            }
        }
        DamageNumberControll._instance.SpawnDamage(damage, transform.position);

    }
}
