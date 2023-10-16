using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] Slider expslider;
    [SerializeField] TMP_Text expLevel;
    [SerializeField] public LevelUpButton[] levelupButtons;
    [SerializeField] public GameObject LevelUpPanel;
    [SerializeField] Weapon[] Weapons;
    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text timeText;
    public TMP_Text kills;
    public int killcount;
    public GameObject Endscreen;
    public GameObject PauseScreen;
    public TMP_Text endTime;
    public GameObject Win;
    public PlayerStatUpgradeDisplay moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickupRangeUpgradeDisplay, maxWeaponsUpgradeDisplay;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
        Kills();
        WIn();
    }
    public void WIn()
    {
        if(killcount >=500)
        {
            Win.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void UpdateCoins()
    {
        coinText.text = "Coin: " + CoinController.instance.currentCoin;
    }
    public void Kills()
    {
        kills.text = "Kills:"+ killcount;
    }
    public void UpdateExperience(int currentExp, int levelexp, int currentlevel)
    {
        expslider.maxValue = levelexp;
        expslider.value = currentExp;
        expLevel.text = "Level :" + currentlevel;
    }
    public void exitLevel()
    {
        LevelUpPanel.SetActive(false);
        Time.timeScale= 1.0f;
    }
    public void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60f);
        float seconds = Mathf.FloorToInt(time % 60f);

        timeText.text = "Time : " + minutes + ":" + seconds.ToString("00");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseUnpause()
    {
        if (PauseScreen.activeSelf == false)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseScreen.SetActive(false);
            if (PauseScreen.activeSelf == false)
            {
                Time.timeScale = 1f;
            }
        }
    }
}
