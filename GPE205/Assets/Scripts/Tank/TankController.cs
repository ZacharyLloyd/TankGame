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
    public enum ControlScheme {WASD, NumberKeys};
    public ControlScheme controlScheme;


    // Update is called once per frame
    void FixedUpdate()
    {
        switch (controlScheme)
        {
            case ControlScheme.WASD:
                WasdControls();
                break;
            case ControlScheme.NumberKeys:
                NumberControls();
                break;
            default:
                break;
        }
    }

    private void NumberControls()
    {
        //Movement
        //If the keypad 5 key is down, add forward to the direction to move the player
        if (Input.GetKey(KeyCode.Keypad5))
        {
            pawn.mover.Move(Vector3.forward);
        }
        //If the keypad 2 key is down, add reverse to the direction to moce the player
        if (Input.GetKey(KeyCode.Keypad2))
        {
            pawn.mover.Move(-Vector3.forward);
        }
        //Rotation
        //If the keypad 1 key is down, multiply by the negative rotateSpeed
        if (Input.GetKey(KeyCode.Keypad1))
        {
            pawn.mover.Rotate(-pawn.rotateSpeed * Time.deltaTime);
        }
        //If the keypad 3 key is down, multiply by the positive rotateSpeed
        if (Input.GetKey(KeyCode.Keypad3))
        {
            pawn.mover.Rotate(pawn.rotateSpeed * Time.deltaTime);
        }
        //If keypad 4 is pressed rotate the turret to the left
        if (Input.GetKey(KeyCode.Keypad4))
        {
            pawn.turretRotation.Rotate(-pawn.turretRotateSpeed * Time.deltaTime);
        }
        //If keypad 6 is pressed rotate the turret to the right
        if (Input.GetKey(KeyCode.Keypad6))
        {
            pawn.turretRotation.Rotate(pawn.turretRotateSpeed * Time.deltaTime);
        }
        //If the Up arrow key is down, 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pawn.shotsPerSecondCurrent <= 0)
            {
                shoot.TankShoot(shoot.bulletPrefab);
                pawn.shotsPerSecondCurrent = pawn.shotsPerSecondMax;
            }
        }
        //If you press escape while playing quit the game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void WasdControls()
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
            if (pawn.shotsPerSecondCurrent <= 0)
            {
                shoot.TankShoot(shoot.bulletPrefab);
                pawn.shotsPerSecondCurrent = pawn.shotsPerSecondMax;
            }
        }
        //Quit from inside the game scene
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
