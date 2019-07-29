using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPowerup : Powerup
{
    public float boostAmount;
    //Applying the speed powerup
    public override void OnApplyPowerup(GameObject target)
    {
        TankData tempData = target.GetComponent<TankData>();
        tempData.moveSpeed += boostAmount;
    }
    //Removing the speed power up
    public override void OnRemovePowerup(GameObject target)
    {
        TankData tempData = target.GetComponent<TankData>();
        tempData.moveSpeed -= boostAmount;
    }
}
