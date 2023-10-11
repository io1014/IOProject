using UnityEngine;
public class Experience : MonoBehaviour
{
    [SerializeField] public int expvalue;

    public int value { get { return expvalue; } set { expvalue = value; } }
    bool movingToPlayer;
    float movespeed = 3;
    float timeCheck = 0.2f;
    float Checkcounter;
    PlayerController player;
    void Start()
    {
        player = PlayerHealthController.Instance.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (movingToPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movespeed * Time.deltaTime);
        }
        else
        {
            Checkcounter -= Time.deltaTime;
            if (Checkcounter <= 0)
            {
                Checkcounter = timeCheck;
                if (Vector3.Distance(transform.position, player.transform.position) < player.Setrange)
                {
                    movingToPlayer = true;
                    movespeed += player.SetSpeed;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExperienceController.instance.GetExp(expvalue);
            Destroy(gameObject);
        }
    }
}
