using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Setting up the singleton
    public static GameManager instance;
    //Used to keep track of the player
    public List<TankData> tanks;
    //Keep track of the powerups
    public List<Powerup> powerups;
    //Used to instanciate the bullet
    public int bulletInstance;


    private void Awake()
    {
        #region Singleton
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
        #endregion
    }
    private void Update()
    {
    }
    private void Start()
    {
        
    }
}
