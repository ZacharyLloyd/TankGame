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
    //Player lives
    public int playerLives;
    //Player 1 
    public GameObject P1;
    //Player one score
    public int P1score;
    //Player 2 
    public GameObject P2;
    //Player two score
    public int P2score;
    //Score to be added
    public int score;
    //Highscore
    public int highscore;
    // Delay before game over returns to main menu
    public float gameOverDelay;

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
    public void CheckGameOver()
    {
        if (P2 != null)
        {
            if (P1 == null && P2.GetComponent<TankData>().isDead == true)
            {
                Debug.Log("You lost");
                // Game Over
                // display game over UI screen.
                // This is awesome!
                // Do this by setting game over screen 
                // (canvas gameObject).setActive(true) << General code to use
                // Them run a coroutine to delay the return to main menu
                StartCoroutine(Delay());
            } 
        }
        if (P1 != null)
        {
            if (P2 == null && P1.GetComponent<TankData>().isDead == true)
            {
                Debug.Log("You lost");
                StartCoroutine(Delay());
            } 
        }
    }

    IEnumerator Delay()
    {
        // This will wait for a number of seconds before returning to main menu
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene("Menu");
    }
    public void CheckWin()
    {
        if(tanks.Count == 1)
        {
            Debug.Log("You won");
            // Win
            // display game over UI screen.
            // This is awesome!
            // Do this by setting game over screen 
            // (canvas gameObject).setActive(true) << General code to use
            // Them run a coroutine to delay the return to main menu
            StartCoroutine(Delay());
        }
    }
}
