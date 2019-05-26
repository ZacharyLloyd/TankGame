﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
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
    }
    public void EShoot(GameObject enemyBulletPrefab, float seconds)
    {
        Instantiate(enemyBulletPrefab);
        timer.StartTimer();
        if (timer.currentTime > seconds)
        {
            timer.ResetTime();
            Destroy(this.gameObject);
        }
    }
}
