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
    public Transform spawnpoint;
    public Transform powerupSpawnpoint;

    public void Start()
    {
        SpawnManager.spawnInstance.SpawnPoints.Add(spawnpoint);
    }
}
