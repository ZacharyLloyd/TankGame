using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    //All the components tied to the tank
    [Header("Components")]
    public Transform tf;
    public TankPawn mover;

    //All the variables that are tied to the tank
    [Header("Variables")]
    public float moveSpeed;
    public float reverseMoveSpeed;
    public float shotsPerSecond;
    public float rotateSpeed;

    /*This is where we grab the tank's transform
    along with assigning the pawn component to the TankPawn class
    in the Awake function*/
    private void Awake()
    {
        tf = GetComponent<Transform>();
        mover = GetComponent<TankPawn>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
