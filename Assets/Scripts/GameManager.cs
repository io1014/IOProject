using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public static GameManager instance;
    public PoolManager pool;
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    private void Awake()
    {
        instance = this; 
    }
    private void Update()
    {
        gameTime += Time.deltaTime;

        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
