using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime = 0;
    public float restartTime;
    public bool startTime = false;

    // Start is called before the first frame update
    void Start()
    {
        restartTime = currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            currentTime += Time.deltaTime;
        }
    }
    public void StartTimer()
    {
        startTime = true;
    }
    public void ResetTime()
    {
        startTime = false;
        currentTime = restartTime;
    }
}
