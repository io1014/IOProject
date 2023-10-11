using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField]public  int expvalue ;

    public int value { get { return expvalue; } set { expvalue = value; } }


    bool movingToPlayer;
    float movespeed =3;

    float timeCheck = 0.2f;
    float Checkcounter;

    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerHealthController.Instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
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
        if(collision.CompareTag("Player"))
        {
            ExperienceController.instance.GetExp(expvalue);

            Destroy(gameObject);
        }
    }
}
