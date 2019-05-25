using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public Transform tf;
    public TankData data;
    public new CameraMovement camera;


    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponentInParent<Transform>();
        data = GetComponentInParent<TankData>();
        camera = GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Rotate(float direction)
    {
        data.turrettf.Rotate(new Vector3(0, direction * data.turretRotateSpeed * Time.deltaTime, 0));
        
    }
}
