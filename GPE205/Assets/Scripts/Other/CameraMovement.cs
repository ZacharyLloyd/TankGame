using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement cameraFollow;
    public TankData data;
    //Setting properties that will be used in this class
    public GameObject target; //Targeted GameObject to change its location through its GameObject component
    public Vector3 offset; //Setting offset of camera
    readonly private Space offsetPositionSpace = Space.Self;
    readonly private bool lookAt = true;

    //Finding the player for the camera to follow
    void Start()
    {
        target = FindObjectOfType<TurretRotation>().gameObject;
        data = FindObjectOfType<TankData>();
    }
    // Calls every frame after regular update but there is none in this case
    void FixedUpdate()
    {
        Refresh();
    }
    public void Refresh()
    {
        if(offsetPositionSpace == Space.Self)
        {
            if (target != null)
            {
                transform.position = target.transform.TransformPoint(offset); 
            }
        }
        else
        {
            transform.position = target.transform.position + offset;
        }
        //Figure out the rotation
        if(lookAt)
        {

            if (target != null)
            {
                transform.LookAt(target.transform); 
            }
        }
        else
        {
            transform.rotation = target.transform.rotation;
        }
    }
}
