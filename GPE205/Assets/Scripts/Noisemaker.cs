
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noisemaker : MonoBehaviour
{
    public float playerVolume; //Setting the player volume to be adjusted by designers
    public float slowDownVolume; //How the volume fades away to nothing

    // Update is called once per frame
    void Update()
    {
        //Each frame noise gets lower until it hits zero/nothing
        if (playerVolume > 0)
        {
            playerVolume -= slowDownVolume;
        }
    }
}