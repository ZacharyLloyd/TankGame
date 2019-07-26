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
    public LevelGenerator LevelInfo;
    public List<int> SpawnPointsUsed;

    // Start is called before the first frame update
    void Start()
    {
        spawnInstance = this;
        SpawnPointsUsed.Clear();
    }
    public void InitialSpawn()
    {
        SpawnPlayer();
        for (int i = 0; i < Enemies.Count; i++)
        {
            SpawnEnemy(Enemies[i]);
        }
    }
    public int PickingEnemySpawn()
    {
        int randomPoint = PickRandomSpawnPoint();
        while (randomPoint == playerSpawnPoint && SpawnPointsUsed.Contains(randomPoint))
        {
                randomPoint = PickRandomSpawnPoint(); 
        }
        return randomPoint;
    }
    private int PickRandomSpawnPoint()
    {
        int randomNum = Random.Range(0, SpawnPoints.Count - 1);
        if (!SpawnPointsUsed.Contains(randomNum))
        {
            SpawnPointsUsed.Add(randomNum);
            return randomNum;
        }
        else
        {
            return PickRandomSpawnPoint();
        }

    }
    public void SpawnPlayer()
    {
        playerSpawnPoint = PickRandomSpawnPoint();
        Instantiate(Player, SpawnPoints[playerSpawnPoint].position, SpawnPoints[playerSpawnPoint].rotation);
    }
    public void SpawnEnemy(GameObject enemyToSpawn)
    {
        int randomNum = PickingEnemySpawn();
        Instantiate(enemyToSpawn, SpawnPoints[randomNum].position, SpawnPoints[randomNum].rotation);
    }
}