using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Setting up the singleton
    public static GameManager instance;
    //Used to keep track of the player
    public List<TankController> players;
    //Used to instanciate the bullet
    public int bulletInstance;
    public TankData data;
    public float damage;

    private void Awake()
    {
        //Using the singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
    }
    private void Start()
    {
        data.health = data.maxHealth;
    }
}
