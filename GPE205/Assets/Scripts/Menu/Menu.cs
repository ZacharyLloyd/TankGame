using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Play the game
    public void Play()
    {
        GameManager.instance.Goto_Scene(GameManager.instance.sceneName);
    }
    //Go to the settings
    public void GoToSettings()
    {
        GameManager.instance.Goto_Scene(GameManager.instance.sceneName);
    }
    //Quit the game
    public void Quit()
    {
        Application.Quit();
    }
}
