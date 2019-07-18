using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : MonoBehaviour
{
    public SpeedPowerup powerup;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // Get the powerup controller from the object that entered our trigger
        PowerupController tempPUC = other.GetComponent<PowerupController>();
        // If it is NOT null
        if (tempPUC != null)
        {
            // Tell to apply the powerup on this object
            tempPUC.ApplyPowerup(powerup);

            // Destroy this pickup
            Destroy(gameObject);
        }
    }
}
