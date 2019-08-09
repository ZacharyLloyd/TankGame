using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplayer : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (Settings.settingsInstance.isMulitplayerEnabled)
        {
            firstCamera.gameObject.SetActive(true);
            firstCamera.rect = new Rect (0, 0.5f, 1, 0.5f);
            secondCamera.gameObject.SetActive(true);
            secondCamera.rect = new Rect (0, 0, 1, 0.5f);
        }
        else
        {
            firstCamera.gameObject.SetActive(true);
            firstCamera.rect = new Rect(0, 0, 1, 1);
            secondCamera.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}