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
        Coin newcoin = Instantiate(coin, pos + new Vector3(0.2f,0.1f,0f), Quaternion.identity);
        newcoin.coinAmount = coinvalue;
        newcoin.gameObject.SetActive(true);
    }

    public void AddCoin(int CoinAdd)
    {
        Coin += CoinAdd;
        UIController.Instance.UpdateCoins();
    }
}
