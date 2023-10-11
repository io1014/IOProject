using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    [SerializeField] Coin coin;

    public int Coin;

    private void Awake()
    {
        if(instance == null)
        instance= this;
    }
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void SpawnCoin(Vector3 pos, int coinvalue)
    {
        Instantiate(coin, pos, Quaternion.identity);
    }

    public void AddCoin(int CoinAdd)
    {
        Coin += CoinAdd;

        UIController.Instance.UpdateCoins();

    }
}
