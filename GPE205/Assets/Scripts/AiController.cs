using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    //Creating a reference for timer to use its properties and methods
    public Timer timer;
    //The properties used in this script
    public Transform enemyPointOfFire;
    public GameObject enemyBulletPrefab;

    // Update is called once per frame
    void Update()
    {
        enemyBulletPrefab.transform.position = enemyPointOfFire.position;
        enemyBulletPrefab.transform.rotation = enemyPointOfFire.rotation;
        if (GameManager.instance.currentEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void EnemyShoot(GameObject enemyBulletPrefab)
    {
            Instantiate(enemyBulletPrefab);
    }
    public void InitiateEnemyControls(float seconds)
    {
        timer.StartTimer();
        if (timer.currentTime > seconds)
        {
            EnemyShoot(enemyBulletPrefab.gameObject);
            timer.ResetTime();
        }
    }
}
