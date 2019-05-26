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
    public float currentPlayerHealth;
    public float maxPlayerHealth;
    public float currentEnemyHealth;
    public float maxEnemyHealth;

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
        Debug.Log(currentPlayerHealth);
        Debug.Log(currentEnemyHealth);
    }
    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        currentEnemyHealth = maxEnemyHealth;
    }
    public void DecreaseHealth(float damage)
    {
        if (currentPlayerHealth > 0)
        {
            currentPlayerHealth -= maxPlayerHealth - damage;
        }
    }
    public void DecreaseHealthEmemy(float damage)
    {
        if (currentEnemyHealth > 0)
        {
            currentEnemyHealth -= maxEnemyHealth - damage;
        }
    }
}
