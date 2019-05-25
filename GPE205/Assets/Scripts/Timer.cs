using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Setting properties that will be used in this scipt
    public float currentTime = 0;
    public float restartTime;
    public bool startTime = false;

    // Start is called before the first frame update
    //This is where restartTime will be set to zero from currentTime which will be used later
    void Start()
    {
        restartTime = currentTime;
    }

    // Update is called once per frame
    /*Check to make sure start time is true or false,
    if false it does nothing if true start counting*/
    void Update()
    {
        if (startTime)
        {
            currentTime += Time.deltaTime;
        }
    }
    //StartTimer is used to switch the bool startTime to true
    public void StartTimer()
    {
        startTime = true;
    }
    /*Reset time switches startTime back to false
    while also setting currentTime back to restartTime
    which is equal to zero*/
    public void ResetTime()
    {
        startTime = false;
        currentTime = restartTime;
    }
}
