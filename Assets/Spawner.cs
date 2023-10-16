using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    public int level;
    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.instance.gameTime / 10f);

        if(timer >0.2f)
        {
            GameManager.instance.pool.Get(1);
            timer = 0;
            Spawn();
        }
    }
    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(level);
        enemy.transform.position = spawnPoint[UnityEngine.Random.Range(1,spawnPoint.Length)].position;
    }

    [Serializable]
    public class SpawnData
    {
        public int spriteType;
        public float spawnTime;
        public int health;
        public float speed;
    }
}
