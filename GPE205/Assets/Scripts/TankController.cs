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
    public enum ControlScheme {WASD, ArrowKeys };
    public ControlScheme controlScheme;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Start with the assumption that the player is not moving
        Vector3 directionToMove = Vector3.zero;

        //If the WASD control scheme is selected
        if (controlScheme == ControlScheme.WASD)
        {
            //Movement
            //If the W key is down, add forward to the direction the player is moving
            if (Input.GetKey(KeyCode.W))
            {
                directionToMove += Vector3.forward;
            }
            //If the S key is down, add reverse to the direction the player is moving
            if (Input.GetKey(KeyCode.S))
            {
                directionToMove += -Vector3.forward;
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
                    aiController.EnemyShoot(aiController.enemyBulletPrefab);
                }
            }
        }
        //If the ArrowKeys control scheme is selected
        else if (controlScheme == ControlScheme.ArrowKeys)
        {
            //Movement
            //If the UpArrow key is down, add forward to the direction to move the player
            if (Input.GetKey(KeyCode.UpArrow))
            {
                directionToMove += Vector3.forward;
            }
            //If the DownArrow key is down, add reverse to the direction to moce the player
            if (Input.GetKey(KeyCode.DownArrow))
            {
                directionToMove += -Vector3.forward;
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
        /*After checking all inputs from the player this tells the mover
        to move in the final calculated direction*/
        pawn.mover.Move(directionToMove);
    }
}
