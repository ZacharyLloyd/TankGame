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
        var mybullet = Instantiate(bulletPrefab, pointOfFire.position, pointOfFire.rotation);
        mybullet.GetComponent<BulletMover>().owner = this.GetComponentInParent<TankData>().gameObject;
        mybullet.GetComponent<BulletMover>().data = this.GetComponentInParent<TankData>();
        //Play the shoot sound
        AudioManager.mastersounds.Play("Shoot");
        return true;
    }
    public void InitateEnemyShoot(float secondsUntilShoot)
    {
        timer.StartTimer(2);
        if(timer.currentTime[2] > secondsUntilShoot)
        {
            TankShoot(bulletPrefab.gameObject);
            //Play the shoot sound
            AudioManager.mastersounds.Play("Shoot");
            timer.ResetTime(2, false);
        }
    }
}
