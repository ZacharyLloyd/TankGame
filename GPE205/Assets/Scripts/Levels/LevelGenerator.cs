using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> roomPrefabs;
    public List<Transform> spawnPoints;
    public List<Transform> powerupSpawnPoints;
    public GameObject[,] grid;

    //Data for the rooms and level
    public int numCols;
    public int numRows;

    public float tileWidth = 50.0f;
    public float tileHeight = 50.0f;

    //Seed stuff
    private Random.State seedGenerator;
    public int genSeed;
    private bool seedGenInitiate = false;

    //Map of the day stuff
    public bool mapOfTheDay = false;
    private DateTime _lastMapOfDay = DateTime.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        BuildLevel();
        SendSpawnPoint();
        SendPowerupSpawnPoint();
        SpawnManager.spawnInstance.InitialSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BuildLevel()
    {

        //Seed the random generator
        Random.InitState(GenerateSeed());

        // Create the 2D Array
        grid = new GameObject[numCols, numRows];

        // For loops through all the rooms 
        for (int currentCol = 0; currentCol < numCols; currentCol++)
        {
            for (int currentRow = 0; currentRow < numRows; currentRow++)
            {
                // Instantiate a room
                GameObject tempRoom = Instantiate(RandomRoom());
                // Add to the grid array
                grid[currentCol, currentRow] = tempRoom;
                // Move it into position
                tempRoom.transform.position = new Vector3(currentCol * tileWidth, 0, -currentRow * tileHeight);
                // Name my room
                tempRoom.name = "Room (" + currentCol + "," + currentRow + ")";
                // Make it a child of this object
                tempRoom.GetComponent<Transform>().parent = this.gameObject.GetComponent<Transform>();

                Room roomScript = tempRoom.GetComponent<Room>();
                //Opening up the level
                if (currentCol != 0)
                {
                    roomScript.doorWest.SetActive(false);
                }

                if (currentCol != numCols - 1)
                {
                    roomScript.doorEast.SetActive(false);
                }

                if (currentRow != 0)
                {
                    roomScript.doorNorth.SetActive(false);
                }

                if (currentRow != numRows - 1)
                {
                    roomScript.doorSouth.SetActive(false);
                }
                for (int i = 0; i < tempRoom.GetComponent<Room>().spawnpoint.Count; i++)
                {
                    spawnPoints.Add(tempRoom.GetComponent<Room>().spawnpoint[i]); 
                }
                powerupSpawnPoints.Add(tempRoom.GetComponent<Room>().powerupSpawnpoint);
            }
        }
    }
    //Destroy the level
    public void DestroyLevel()
    {
        //Cycle through the rooms and destroy them
        for (int currentRow = 0; currentRow < numRows; currentRow++)
        {
            for (int currentCol = 0; currentCol < numCols; currentCol++)
            {
                Destroy(grid[currentCol, currentRow]);
            }
        }
    }
    //Pick a random room
    private GameObject RandomRoom()
    {
        //Actually picking the rooms randomly
        int roomIndex = Random.Range(0, roomPrefabs.Count);
        return roomPrefabs[roomIndex];
    }
    //Send spawn points to spawn manager
    public void SendSpawnPoint()
    {
        //Cycle through spawn points add them to the list in spawn manager
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            SpawnManager.spawnInstance.SpawnPoints.Add(spawnPoints[i]);
        }
    }
    //Send powerup spawns to powerup manager
    public void SendPowerupSpawnPoint()
    {
        //Cycle through the powerup spawn points add them to the list in power up manager
        for (int i = 0; i < powerupSpawnPoints.Count; i++)
        {
            PowerupManager.powerupInstance.PowerupSpawns.Add(powerupSpawnPoints[i]);
        }
    }
    //Generate a seed
    public int GenerateSeed()
    {
        //Are we creating the map of the day
        switch (mapOfTheDay)
        {
            case true:
                GenerateMapOfTheDay();
                break;
        }
        var temp = Random.state;
        //Start the seed generation if there is not one started
        if (!seedGenInitiate)
        {
            Random.InitState(genSeed);
            seedGenerator = Random.state;
            seedGenInitiate = true;
        }
        Random.state = seedGenerator;
        var generatedSeed = Random.Range(int.MinValue, int.MaxValue);
        seedGenerator = Random.state;
        Random.state = temp;
        return generatedSeed;
    }
    //Generate the map of the day
    public void GenerateMapOfTheDay()
    {
        //Store current time
        if(_lastMapOfDay.AddDays(1) > DateTime.Now)
        {
            genSeed = DateTime.Now.DayOfYear;
            _lastMapOfDay = DateTime.Now;
        }
    }
}
