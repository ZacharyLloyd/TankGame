﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Setting properties that will be used in this class
    public GameObject target; //Targeted GameObject to change its location through its GameObject component
    public float smoothDuration; //Setting the duration of the camera smoothing out/in towards the player
    public Vector3 offset; //Setting offset of camera

    //Finding the player for the camera to follow
    void Start()
    {
        target = FindObjectOfType<TurretRotation>().gameObject;
    }
    // Calls every frame after regular update but there is none in this case
    void FixedUpdate()
    {
        Vector3 setCoordinate = target.transform.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, setCoordinate, smoothDuration);

        transform.position = smoothPosition;
        /*
        Creating a Vector3 that will grab the player's position and add it to the camera offset.
        Create another Vector3 that will go from it's current spot to the player in a smooth motion with a set amount of time.
        smoothPosition variable will then be added to the camera's transform component, applying the change
        in postion every frame assuring that it smoothes out.
        */
    }
}
