using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnInstance;
    public List<GameObject> Enemies;
    public GameObject Player;
    public List<Transform> SpawnPoints;
    public List<Transform> Waypoints;
    public int playerSpawnPoint;
    public LevelGenerator LevelInfo;
    public List<int> SpawnPointsUsed;
    private GameObject spawnedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        spawnInstance = this;
        SpawnPointsUsed.Clear();
    }
    //Starting the spawning
    public void InitialSpawn()
    {
        //Spawn player first
        SpawnPlayer();
        //Cycle through enemies and spawn them
        for (int i = 0; i < Enemies.Count; i++)
        {
            SpawnEnemy(Enemies[i]);
        }
    }
    //Picking the enemy spawn point
    public int PickingEnemySpawn()
    {
        int randomPoint = PickRandomSpawnPoint();
        //Used to make sure the enemies do not spawn with the player or on a spawn already used
        while (randomPoint == playerSpawnPoint && SpawnPointsUsed.Contains(randomPoint))
        {
                randomPoint = PickRandomSpawnPoint(); 
        }
        return randomPoint;
    }
    //Picking a random spawn point
    private int PickRandomSpawnPoint()
    {
        int randomNum = Random.Range(0, SpawnPoints.Count - 1);
        //If the spawn point is not used add it to the list return to be used
        if (!SpawnPointsUsed.Contains(randomNum))
        {
            SpawnPointsUsed.Add(randomNum);
            return randomNum;
        }
        else
        {
            //If it is used pick another spawn point
            return PickRandomSpawnPoint();
        }

    }
    //Spawn the player
    public void SpawnPlayer()
    {
        playerSpawnPoint = PickRandomSpawnPoint();
        spawnedPlayer = Instantiate(Player, SpawnPoints[playerSpawnPoint].position, SpawnPoints[playerSpawnPoint].rotation);
    }
    //Spawn the enemy
    public void SpawnEnemy(GameObject enemyToSpawn)
    {
        int randomNum = PickingEnemySpawn();
        GameObject temp = Instantiate(enemyToSpawn, SpawnPoints[randomNum].position, SpawnPoints[randomNum].rotation);
        temp.GetComponent<AiController>().target = spawnedPlayer.GetComponent<TankData>();
        for (int i = 0; i < Waypoints.Count; i++)
        {
            temp.GetComponent<AiController>().waypoints.Add(Waypoints[i]);
        }
    }
}