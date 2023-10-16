using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool gameActive;
    public float timer;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameActive = true;
    }
    void Update()
    {
        if(gameActive == true)
        {
            timer += Time.deltaTime;
            UIController.Instance.UpdateTimer(timer);
        }   
    }
    public void End()
    {
        gameActive = false;
        StartCoroutine(EndLevel());
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1f);
        float minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60f);
        UIController.Instance.endTime.text = minutes.ToString()   + "mins" + seconds.ToString("00" + "secs");
        UIController.Instance.Endscreen.SetActive(true);
    }
}
