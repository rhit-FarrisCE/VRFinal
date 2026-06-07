using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    List<Powerup> acquiredPowerups = new List<Powerup>();
    List<Powerup> availablePowerups = new List<Powerup>();

    public void Awake()
    {
        
    }

    public void GeneratePowerups()
    {
        //Speed powerup generation
        availablePowerups.Add(GenSpeedPowerup());
    }

    public void acquirePowerup(Powerup powerup)
    {
        bool found = false;
        foreach (Powerup currPowerup in acquiredPowerups)
        {
            if (currPowerup.GetName().Equals(powerup.GetName()))
            {
                found = true;
                currPowerup.UpdatePowerup(powerup);
            }
        }
        if (found == false)
        {
            acquiredPowerups.Add(powerup);
        }
        InitializePowerups();
    }

    private void InitializePowerups()
    {
        
    }

    private Powerup GenSpeedPowerup()
    {
        int randomInt = UnityEngine.Random.Range(1, 100);
        SpeedupPowerup powerup;
        if (randomInt <= 50)
        {
            powerup = new SpeedupPowerup();
            powerup.Initialize(0, 1.5f, "speed");
        } else if (randomInt <= 80)
        {
            powerup = new SpeedupPowerup();
            powerup.Initialize(1, 2f, "speed");
        } else
        {
            powerup = new SpeedupPowerup();
            powerup.Initialize(2, 3f, "speed");
        }
        return powerup;
    }

}
