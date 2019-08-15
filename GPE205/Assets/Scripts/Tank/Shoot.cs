using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public TankData data;
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
        if(data.shotsPerSecondCurrent <= 0)
        {
            TankShoot(bulletPrefab.gameObject);
            //Play the shoot sound
            AudioManager.mastersounds.Play("Shoot");
            data.shotsPerSecondCurrent = data.shotsPerSecondMax;
        }
    }
}
