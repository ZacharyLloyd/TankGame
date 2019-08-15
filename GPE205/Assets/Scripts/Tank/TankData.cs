using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    //All the components tied to the tank
    [Header("Components")]
    public Transform bodytf;
    public Transform turrettf;
    public TankPawn mover;
    public TurretRotation turretRotation;

    //All the variables that are tied to the tank
    [Header("Variables")]
    public float moveSpeed;
    public float shotsPerSecondCurrent;
    public float shotsPerSecondMax;
    public float rotateSpeed;
    public float turretRotateSpeed;
    public float damage;
    public float maxDamage;
    public float health;
    public float maxHealth;
    public Vector3 spawnLocation;
    public int numLives;

    public void Awake()
    {
        bodytf = GetComponent<Transform>();
        mover = GetComponent<TankPawn>();
        if(bodytf == null || turrettf == null || turretRotation == null || mover == null)
        {
            //Do nothing
        }
    }
    public void Start()
    {
        GameManager.instance.tanks.Add(this);
    }
    private void Update()
    {
        if (shotsPerSecondCurrent >= 0)
        {
            shotsPerSecondCurrent -= Time.deltaTime;
        }
        else if (shotsPerSecondCurrent <= 0)
        {
            shotsPerSecondCurrent = 0;
        }
    }
}
