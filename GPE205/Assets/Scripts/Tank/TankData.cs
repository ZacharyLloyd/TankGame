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
    public float reverseMoveSpeed;
    public float shotsPerSecond;
    public float rotateSpeed;
    public float turretRotateSpeed;
    public float playerDamage;
    public float playerHealth;
    public float enemyDamage;
    public float enemyHealth;

    public void Awake()
    {
        bodytf = GetComponent<Transform>();
        mover = GetComponent<TankPawn>();
    }
}
