using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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

    //Setting the destination of where to go next in the game
    [Header("Destination")]
    public string sceneName; //Scene/level name



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
    //This is used for switching scenes/levels
    public void Goto_Scene(string scene_name)
    {
        if (scene_name != null) SceneManager.LoadScene(scene_name);
    }
    public void SettingCameras()
    {

    }
}
