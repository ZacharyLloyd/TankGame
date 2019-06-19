using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingRadar : MonoBehaviour
{
    public bool playerDetected = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }
}
