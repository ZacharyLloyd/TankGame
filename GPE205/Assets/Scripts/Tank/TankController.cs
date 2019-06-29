using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    //Setting references to other scripts to grab their properties and methods
    public AiController aiController;
    public Shoot shoot;
    public TankData pawn;
    //Creating an enum for the ControlScheme allong with giving it a property
    public enum ControlScheme {WASD, ArrowKeys};
    public ControlScheme controlScheme;


    // Update is called once per frame
    void FixedUpdate()
    {
        switch (controlScheme)
        {
            case ControlScheme.WASD:
                wasdControls();
                break;
            case ControlScheme.ArrowKeys:
                //arrowControls();
                break;
            default:
                break;
        }
    }

    private void arrowControls()
    {
        //Movement
        //If the UpArrow key is down, add forward to the direction to move the player
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pawn.mover.Move(Vector3.forward);
        }
        //If the DownArrow key is down, add reverse to the direction to moce the player
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pawn.mover.Move(-Vector3.forward);
        }
        //Rotation
        //If the LeftArrow key is down, multiply by the negative rotateSpeed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pawn.mover.Rotate(-pawn.rotateSpeed * Time.deltaTime);
        }
        //If the RightArrow key is down, multiply by the positive rotateSpeed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pawn.mover.Rotate(pawn.rotateSpeed * Time.deltaTime);
        }
    }

    private void wasdControls()
    {
        //Movement
        //If the W key is down, add forward to the direction the player is moving
        if (Input.GetKey(KeyCode.W))
        {
            pawn.mover.Move(Vector3.forward);
        }
        //If the S key is down, add reverse to the direction the player is moving
        if (Input.GetKey(KeyCode.S))
        {
            pawn.mover.Move(-Vector3.forward);
        }
        //Rotation
        //If the A key is down, multiply by the negative rotateSpeed
        if (Input.GetKey(KeyCode.A))
        {
            pawn.mover.Rotate(-pawn.rotateSpeed * Time.deltaTime);
        }
        //If the D key is down, multiply by the positive rotateSpeed
        if (Input.GetKey(KeyCode.D))
        {
            pawn.mover.Rotate(pawn.rotateSpeed * Time.deltaTime);
        }
        //If the Q key is down, multiply by the negative turretRotateSpeed
        //This allows the turret itself to rotate towards the left
        if (Input.GetKey(KeyCode.Q))
        {
            pawn.turretRotation.Rotate(-pawn.turretRotateSpeed * Time.deltaTime);
        }
        //If the E key is down, multiply by the positive turretRotateSpeed
        //This allows the turret itself to rotate towards the right
        if (Input.GetKey(KeyCode.E))
        {
            pawn.turretRotation.Rotate(pawn.turretRotateSpeed * Time.deltaTime);
        }
        //If the space key is down, 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.instance.bulletInstance != 1)
            {
                shoot.TankShoot(shoot.bulletPrefab);
            }
        }
    }
}
