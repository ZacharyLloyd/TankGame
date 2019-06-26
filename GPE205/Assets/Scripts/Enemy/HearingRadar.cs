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
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerDetected = false;
        }
    }
}
