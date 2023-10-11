using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Spawn;
    float Spawntime = 0.2f;
    float spawnCounter;
    [SerializeField] Transform minSpawn, maxSpawn;
    void Start()
    {
        spawnCounter = Spawntime;
    }
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = Spawntime;
            Instantiate(Spawn[Random.Range(0, Spawn.Length - 1)], SelectSpawnPoint(), transform.rotation);
        }
    }
    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnpoint = Vector3.zero;
        bool spawnerEdge = Random.Range(0f, 1f) > .5f;
        if (spawnerEdge)
        {
            spawnpoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnpoint.x = maxSpawn.position.x;
            }
            else spawnpoint.x = minSpawn.position.x;
        }
        else
        {
            spawnpoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnpoint.y = maxSpawn.position.y;
            }
            else spawnpoint.y = minSpawn.position.y;
        }
        return spawnpoint;
    }
}
