using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Timer timer;
    //Setting a reference to access properties and methods from other scripts
    public Transform pointOfFire;
    public GameObject bulletPrefab;

    /*The TankShoot method causes the bullet to spawn which is then moved 
    by the BulletMover script*/
    public bool TankShoot(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, pointOfFire.position, pointOfFire.rotation);
        return true;
    }
    public void InitateEnemyShoot(float secondsUntilShoot)
    {
        timer.StartTimer(2);
        if(timer.currentTime[2] > secondsUntilShoot)
        {
            TankShoot(bulletPrefab.gameObject);
            timer.ResetTime(2, false);
        }
    }
}
