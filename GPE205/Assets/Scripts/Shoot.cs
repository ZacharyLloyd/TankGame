using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //Setting a reference to access properties and methods from other scripts
    public Transform pointOfFire;
    public GameObject bulletPrefab;

    /*Keep updating the bulletPrefab and pointOfFire to make sure
    they are always at the same spot*/
    private void Update()
    {
        bulletPrefab.transform.position = pointOfFire.position;
        bulletPrefab.transform.rotation = pointOfFire.rotation;
    }
    /*The TankShoot method causes the bullet to spawn which is then moved 
    by the BulletMover script*/
    public void TankShoot(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab);
    }
    
}
