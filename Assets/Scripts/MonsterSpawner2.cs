using UnityEngine;
public class MonsterSpawner2 : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] Monster;
    public int index = 0;
    public float gametime = 0;
    public float spawntime = 0.2f;
    public float spawncounter = 0;


    void Start()
    {
        spawncounter = spawntime;
        
    }
    void Update()
    {
        spawncounter -= Time.deltaTime;
        gametime += Time.deltaTime;

        if(gametime > 20)
        {
            index= 1;
        }
        if(gametime > 40)
        {
            index = 2;
        }
        if(gametime > 60)
        {
            index = 3;
        }
        if (spawncounter <= 0)
        {
            spawncounter = spawntime;
            Spawn();
        }
        
    }

    void Spawn()
    {
        GameObject enemy = Monster[index];
        Instantiate(enemy);
        enemy.transform.position = spawnPoint[UnityEngine.Random.Range(1, spawnPoint.Length)].position;
    }
}
