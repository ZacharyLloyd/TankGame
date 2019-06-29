using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (TankData))]
public class TankPawn : MonoBehaviour
{
    //Setting references to use their properties and methods
    public TankData data;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(data.health <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void Move (Vector3 worldDirectionToMove)
    {
        /*Calculating the player's direction based on the player's rotation
        this way (0,0,1 becomes the player's foward)*/
        Vector3 directionToMove = data.bodytf.TransformDirection(worldDirectionToMove);
        //This is where the player would actually move
        characterController.SimpleMove(directionToMove * (data.moveSpeed * Time.deltaTime));
    }
    public void Rotate (float direction)
    {
        /*This is where the rotation is calculated by taking the
        player's direction and multiplying it by rotationSpeed and time
        to add a force*/
        data.bodytf.Rotate(new Vector3(0, direction * data.rotateSpeed * Time.deltaTime, 0));
    }
    //For AI only
    public void RotateTowards(Vector3 lookVector)
    {
        //Find the vector to the target
        Vector3 vectorToTarget = lookVector;
        //Find quaternion to look down that vector
        Quaternion targetQuaternion = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        //Set the rotation to partial towards that quaternion
        data.bodytf.rotation =
            Quaternion.RotateTowards(data.bodytf.rotation, targetQuaternion, data.rotateSpeed * Time.deltaTime);
    }
}
