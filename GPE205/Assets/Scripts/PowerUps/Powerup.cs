using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Powerup : MonoBehaviour
{
    public float timeRemaining;

    public virtual void OnApplyPowerup(GameObject target) { }
    public virtual void OnRemovePowerup(GameObject target) { }
}
