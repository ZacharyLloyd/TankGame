using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Setting properties that will be used in this scipt
    public float[] currentTime;
    [HideInInspector]public float[] restartTime;
    public bool[] startTime;

    // Start is called before the first frame update
    //This is where restartTime will be set to zero from currentTime which will be used later
    void Start()
    {
        currentTime = new float[12];
        restartTime = new float[12];
        startTime = new bool[12];

        for(int i = 0; i < restartTime.Length; i++)
        {
            restartTime[i] = currentTime[i];
        }
    }


    // Update is called once per frame
    /*Check to make sure start time is true or false,
    if false it does nothing if true start counting*/
    void Update()
    {
        RunTimers();
    }
    private void RunTimers()
    {
        if (startTime[0]) currentTime[0] += Time.deltaTime;
        if (startTime[1]) currentTime[1] += Time.deltaTime;
        if (startTime[2]) currentTime[2] += Time.deltaTime;
        if (startTime[3]) currentTime[3] += Time.deltaTime;
        if (startTime[4]) currentTime[4] += Time.deltaTime;
        if (startTime[5]) currentTime[5] += Time.deltaTime;
        if (startTime[6]) currentTime[6] += Time.deltaTime;
        if (startTime[7]) currentTime[7] += Time.deltaTime;
        if (startTime[8]) currentTime[8] += Time.deltaTime;
        if (startTime[9]) currentTime[9] += Time.deltaTime;
        if (startTime[10]) currentTime[10] += Time.deltaTime;
        if (startTime[11]) currentTime[11] += Time.deltaTime;
    }
    //StartTimer is used to switch the bool startTime to true
    public void StartTimer(int index)
    {
        startTime[index] = true;
    }
    /*Reset time switches startTime back to false
    while also setting currentTime back to restartTime
    which is equal to zero*/
    public void ResetTime(int index, bool continueTimer)
    {
        switch(continueTimer)
        {
            case false:
                startTime[index] = false;
                break;
            default:
                break;
        }
        currentTime[index] = restartTime[index];
    }
}
