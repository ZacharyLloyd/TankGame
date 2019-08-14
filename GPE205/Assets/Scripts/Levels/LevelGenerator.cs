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

    // Start is called before the first frame update
    void Start()
    {
        BuildLevel();
        SendSpawnPoint();
        SendPowerupSpawnPoint();
        SpawnManager.spawnInstance.InitialSpawn();
    }
    private void BuildLevel()
    {
        if(Settings.settingsInstance.isMapOfTheDay == true)
        {
            int now = GenerateMapOfTheDay();
            Random.InitState(now);
        }
        else if(Settings.settingsInstance.isMapRandom == true)
        {

        }
        else if(Settings.settingsInstance.isMapSeeded == true)
        {
            Random.InitState(Settings.settingsInstance.seed);
        }
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
    //Generate the map of the day
    public int GenerateMapOfTheDay()
    {
        string day = DateTime.Now.Day.ToString();
        string month = DateTime.Now.Month.ToString();
        string year = DateTime.Now.Year.ToString();
        string nowSeed = day + month + year;
        int currentSeed = int.Parse(nowSeed);
        return currentSeed;
    }
}