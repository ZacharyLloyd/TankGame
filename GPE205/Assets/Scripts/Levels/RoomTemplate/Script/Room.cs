using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject doorNorth;
    public GameObject doorSouth;
    public GameObject doorEast;
    public GameObject doorWest;
    public List<Transform> waypoints;
    public List<Transform> spawnpoint;
    public Transform powerupSpawnpoint;

    public void Awake()
    {
        for (int i = 0; i < spawnpoint.Count; i++)
        {
            SpawnManager.spawnInstance.SpawnPoints.Add(spawnpoint[i]); 
        }
        for (int i = 0; i < waypoints.Count; i++)
        {
            SpawnManager.spawnInstance.Waypoints.Add(waypoints[i]);
        }
    }
}
