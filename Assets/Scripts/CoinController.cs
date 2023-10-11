using UnityEngine;
public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    [SerializeField] Coin coin;
    public int Coin;
    private void Awake()
    {
        if (instance == null)
            instance = this;
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
