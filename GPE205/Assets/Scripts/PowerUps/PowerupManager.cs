using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager powerupInstance; //Used to access in another script
    public List<Transform> PowerupSpawns; //List for powerup spawn points
    public List<GameObject> Powerups; //List for powerups
    public int powerupSpawnPoint; //Where the powerup will spawn
    private GameObject objectSpawned;

    private void Start()
    {
        powerupInstance = this;
    }
    private void Update()
    {
        if (objectSpawned == null)
        {
            SpawnPowerup();
        }
    }

    private int PickRandomPowerupSpawn()
    {
        return Random.Range(0, PowerupSpawns.Count - 1);
    }
    private int PickRandomPowerup()
    {
        return Random.Range(0, Powerups.Count - 1);
    }
    public void SpawnPowerup()
    {
        objectSpawned = Instantiate(Powerups[PickRandomPowerup()], PowerupSpawns[PickRandomPowerupSpawn()]);
    }
}
