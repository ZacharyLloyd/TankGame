using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerConnector : MonoBehaviour
{
    //Connecting the game manager to another script to be used in a scene the game manager may not be in
    public void SwitchScene(string sceneName)
    {
        GameManager.instance.Goto_Scene(sceneName);
    }
}
