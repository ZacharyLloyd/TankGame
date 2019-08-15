using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    //Setting references to other scripts that will be used
    public Transform tf;
    public TankData data;


    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponentInParent<Transform>();
        data = GetComponentInParent<TankData>();
    }
    /*This is where the turret rotates by passing in a direction
    to calculate which way to rotate. It grabs the turrettf from TankData
    to rotate from there. The rotation happens by multiplying the direction by the
    turretRotationSpeed and time to rotate accordingly*/
    public void Rotate(float direction)
    {
        data.turrettf.Rotate(new Vector3(0, direction * data.turretRotateSpeed * Time.deltaTime, 0));
        
    }
}
