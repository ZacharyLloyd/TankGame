using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public static CameraMovement cameraFollow;
    //Setting properties that will be used in this class
    public TurretRotation targetToFollow;
    public Vector3 offset; //Setting offset of camera
    readonly private Space offsetPositionSpace = Space.Self;
    readonly private bool lookAt = true;

    // Calls every frame after regular update but there is none in this case
    void FixedUpdate()
    {
        if (targetToFollow != null)
        {
            Refresh(); 
        }
    }
    public void Refresh()
    {
        if(offsetPositionSpace == Space.Self)
        {
            if (targetToFollow != null)
            {
                transform.position = targetToFollow.transform.TransformPoint(offset); 
            }
        }
        else
        {
            transform.position = targetToFollow.transform.position + offset;
        }
        //Figure out the rotation
        if(lookAt)
        {

            if (targetToFollow != null)
            {
                transform.LookAt(targetToFollow.transform); 
            }
        }
        else
        {
            transform.rotation = targetToFollow.transform.rotation;
        }
    }
}
