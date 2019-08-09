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
    [SerializeField]
    private List<GameObject> spawnedPlayer;
    public Camera cam1;
    public Camera cam2;

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
        //Pick a random spawn point
        playerSpawnPoint = PickRandomSpawnPoint();
        //Actually spawn the player
        spawnedPlayer.Add(Instantiate(Player, SpawnPoints[playerSpawnPoint].position, SpawnPoints[playerSpawnPoint].rotation));
        //Set the players control scheme
        spawnedPlayer[0].GetComponentInChildren<TankController>().controlScheme = TankController.ControlScheme.WASD;
        //Set the player's camera
        cam1.gameObject.GetComponent<CameraMovement>().targetToFollow = spawnedPlayer[0].GetComponentInChildren<TurretRotation>();
        //Are we playing multiplayer?
        if (Settings.settingsInstance.isMulitplayerEnabled == true)
        {
            //Spawn the second player
            spawnedPlayer.Add(Instantiate(Player, SpawnPoints[playerSpawnPoint].position, SpawnPoints[playerSpawnPoint].rotation));
            //Give the second player a control scheme
            spawnedPlayer[1].GetComponentInChildren<TankController>().controlScheme = TankController.ControlScheme.NumberKeys;
            //Give the second player a camera
            cam2.gameObject.GetComponent<CameraMovement>().targetToFollow = spawnedPlayer[1].GetComponentInChildren<TurretRotation>();
        }
    }
    //Spawn the enemy
    public void SpawnEnemy(GameObject enemyToSpawn)
    {
        //Pick the enemy spawn point
        int randomNum = PickingEnemySpawn();
        //Spawn the enemy
        GameObject temp = Instantiate(enemyToSpawn, SpawnPoints[randomNum].position, SpawnPoints[randomNum].rotation);
        if (!Settings.settingsInstance.isMulitplayerEnabled)
        {
            //Set the target to player one
            temp.GetComponent<AiController>().target = spawnedPlayer[0].GetComponent<TankData>(); 
        }
        //If multiplayer is enabled
        else
        {
            //Pick a random number
            int rand = Random.Range(0, 1);
            //For player two
            if (rand == 1)
            {
                //If random number is for player two target is player two
                temp.GetComponent<AiController>().target = spawnedPlayer[1].GetComponent<TankData>();
            }
            //For player one
            else
            {
                //If the random number is for player one set the target to player one
                temp.GetComponent<AiController>().target = spawnedPlayer[0].GetComponent<TankData>();
            }
        }
        //Cycle through the waypoints
        for (int i = 0; i < Waypoints.Count; i++)
        {
            //Add them to the Ai's list of waypoints
            temp.GetComponent<AiController>().waypoints.Add(Waypoints[i]);
        }
    }
}