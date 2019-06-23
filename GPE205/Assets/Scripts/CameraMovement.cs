using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement cameraFollow;
    public TankData data;
    //Setting properties that will be used in this class
    public GameObject target; //Targeted GameObject to change its location through its GameObject component
    public float smoothDuration; //Setting the duration of the camera smoothing out/in towards the player
    public float cameraRotationSpeed;//How fast the camera rotates around the player
    public Vector3 offset; //Setting offset of camera
    Vector3 setCoordinates; //Setting up camera position
    Vector3 smoothPosition;//Position used to create a smooth effect for the camera
    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;

    //Finding the player for the camera to follow
    void Start()
    {
        target = FindObjectOfType<TankController>().gameObject;
        data = FindObjectOfType<TankData>();
    }
    // Calls every frame after regular update but there is none in this case
    void FixedUpdate()
    {
        Refresh();
        //Vector3 setCoordinate = target.transform.position + offset;

        //Vector3 smoothPosition = Vector3.Lerp(transform.position, setCoordinate, smoothDuration);

        //transform.position = smoothPosition;
        /*
        Creating a Vector3 that will grab the player's position and add it to the camera offset.
        Create another Vector3 that will go from it's current spot to the player in a smooth motion with a set amount of time.
        smoothPosition variable will then be added to the camera's transform component, applying the change
        in postion every frame assuring that it smoothes out.
        */
    }
    public void Refresh()
    {
        if(offsetPositionSpace == Space.Self)
        {
            transform.position = target.transform.TransformPoint(offset);
        }
        else
        {
            transform.position = target.transform.position + offset;
        }
        //Figure out the rotation
        if(lookAt)
        {
            transform.LookAt(transform.transform);
        }
        else
        {
            transform.rotation = target.transform.rotation;
        }
    }
}
