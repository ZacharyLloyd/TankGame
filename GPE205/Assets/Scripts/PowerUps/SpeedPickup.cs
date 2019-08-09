using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    public SpeedPowerup powerup;
    //If collison occurs
    void OnTriggerEnter(Collider other)
    {
        // Get the powerup controller from the object that entered our trigger
        PowerupController tempPUC = other.GetComponent<PowerupController>();
        // If it is NOT null
        if (tempPUC != null)
        {
            //Play pickup noise
            AudioManager.mastersounds.Play("Powerup");
            // Tell to apply the powerup on this object
            tempPUC.ApplyPowerup(powerup);

            // Destroy this pickup
            Destroy(gameObject);
        }
    }
}
