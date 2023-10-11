using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinAmount = 1;

    bool movingToPlayer;
    public float moveSpeed;

    float timeCheck =0.2f;
    float checkCounter;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerHealthController.Instance.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (movingToPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }

        else
        {
            checkCounter -= Time.deltaTime;
            if (checkCounter <= 0)
            {
                checkCounter = timeCheck;

                if (Vector3.Distance(transform.position, player.transform.position) < player.Setrange)
                {
                    movingToPlayer = true;
                    moveSpeed += player.SetSpeed;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CoinController.instance.AddCoin(coinAmount);

            Destroy(gameObject);
        }
    }
}






