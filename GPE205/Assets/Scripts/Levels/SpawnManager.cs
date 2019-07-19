using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnInstance;
    public List<GameObject> Enemies;
    public GameObject Player;
    public List<Transform> SpawnPoints;
    public int playerSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        for (int i = 0; i < Enemies.Count; i++)
        {
            SpawnEnemy(Enemies[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int PickingEnemySpawn()
    {
        int randomPoint = PickRandomSpawnPoint();
        while (randomPoint == playerSpawnPoint)
        {
            randomPoint = PickRandomSpawnPoint();
        }
        return randomPoint;
    }

    private int PickRandomSpawnPoint()
    {
        return Random.Range(0, SpawnPoints.Count - 1);
    }

    public void SpawnPlayer()
    {
        playerSpawnPoint = PickRandomSpawnPoint();
        Instantiate(Player, SpawnPoints[playerSpawnPoint]);
    }
    public void SpawnEnemy(GameObject enemyToSpawn)
    {
        Instantiate(enemyToSpawn, SpawnPoints[PickingEnemySpawn()]);
    }
}
