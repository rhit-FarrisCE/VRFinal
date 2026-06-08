using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedupPowerup : Powerup
{

    private float speedMultiplier;

    private GameObject trigger;

    public void Initialize(int rarity, float speedMultiplier, string name)
    {
        this.rarity = rarity;
        this.speedMultiplier = speedMultiplier;
        this.name = name;
        trigger = GameObject.Find("SpeedupTrigger");
    }
    
    public override void UpdatePowerup(Powerup otherPowerup)
    {
        SpeedupPowerup other = (SpeedupPowerup) otherPowerup;
        speedMultiplier += other.getMult();
    }

    public float getMult()
    {
        return speedMultiplier;
    }

    public override string GetDescription()
    {
        if (rarity == 0)
        {
            return "(COMMON) Speed + 50%";
        } else if (rarity == 1)
        {
            return "(RARE) Speed + 100%";
        } else
        {
            return "(EPIC) Speed + 200%";
        }
    }

    public override void SetActive()
    {
        trigger.GetComponent<SpeedTrigger>().SetSpeedMod(speedMultiplier);
    }

    public override void SetInactive()
    {
        trigger.GetComponent<SpeedTrigger>().ResetSpeedMod();
    }
}
