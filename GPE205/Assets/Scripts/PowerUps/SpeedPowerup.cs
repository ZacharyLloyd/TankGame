using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPowerup : Powerup
{
    public float boostAmount;

    public override void OnApplyPowerup(GameObject target)
    {
        TankData tempData = target.GetComponent<TankData>();
        tempData.moveSpeed += boostAmount;
    }

    public override void OnRemovePowerup(GameObject target)
    {
        TankData tempData = target.GetComponent<TankData>();
        tempData.moveSpeed -= boostAmount;
    }
}
