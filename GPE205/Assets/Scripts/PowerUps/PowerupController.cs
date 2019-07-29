using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    public List<Powerup> powerups;

    // Update is called once per frame
    void Update()
    {
        HandlePowerupTimers();
    }
    //Handling the timer for the powerups
    public void HandlePowerupTimers()
    {
        List<Powerup> toBeRemoved = new List<Powerup>();

        foreach (Powerup temp in powerups)
        {
            // countdown the timer
            temp.timeRemaining -= Time.deltaTime;
            // If the timer <=0
            if (temp.timeRemaining <= 0)
            {
                // UGH! Can't remove from powerups, because we are iterating through powerups
                // RemovePowerup(temp);

                // Add to a different list! 
                toBeRemoved.Add(temp);
            }
        }

        // Now that we are no longer iterating through powerup, remove everything from toBeRemoved
        foreach (Powerup temp in toBeRemoved)
        {
            RemovePowerup(temp);
        }

    }
    //Remove the power up
    public void RemovePowerup(Powerup powerup)
    {
        // Call the on remove
        powerup.OnRemovePowerup(gameObject);
        // Remove powerup from list
        powerups.Remove(powerup);
    }
    //Apply the powerup
    public void ApplyPowerup(Powerup powerup)
    {
        // Add powerup to the list, 
        powerups.Add(powerup);
        // Call the OnApply event for that powerup
        powerup.OnApplyPowerup(gameObject);
    }
}
