using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Timer timer;
    public Transform pointOfFire;
    public GameObject bulletPrefab;

    private void Update()
    {
        bulletPrefab.transform.position = pointOfFire.position;
        bulletPrefab.transform.rotation = pointOfFire.rotation;
    }
    public void TankShoot(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab);
    }
    
}
