using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomTests : MonoBehaviour
{

    public int seed = 100;

    // Start is called before the first frame update
    void Start()
    {

        DateTime currentTime = DateTime.Now.Date;  // Current date only - for map of the day


        Random.InitState((int)currentTime.Ticks);
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(Random.value);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
