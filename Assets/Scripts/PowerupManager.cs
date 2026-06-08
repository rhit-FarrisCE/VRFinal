using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PowerupManager : MonoBehaviour
{

    public static PowerupManager Instance;
    List<Powerup> acquiredPowerups = new List<Powerup>();
    List<Powerup> availablePowerups = new List<Powerup>();

    [Header("UI")]
    public GameObject powerupUI;
    public TextMeshProUGUI speedPH;
    public TextMeshProUGUI pinsPH;
    public TextMeshProUGUI ballsPH;

    public void Awake()
    {
        Instance = this;
        powerupUI.SetActive(false);
    }

    public void GeneratePowerups()
    {
        //Speed powerup generation
        availablePowerups.Add(GenSpeedPowerup());
        //Light pins powerup generation
        availablePowerups.Add(GenLightPinsPowerup());
        //Heavy balls powerup generation
        availablePowerups.Add(GenHeavyBallsPowerup());

        foreach (Powerup powerup in availablePowerups)
        {
            if (powerup.compareName("speed"))
            {
                speedPH.text = powerup.GetDescription();
            } else if (powerup.compareName("pins"))
            {
                pinsPH.text = powerup.GetDescription();
            } else
            {
                ballsPH.text = powerup.GetDescription();
            }
        }
    }

    public void AcquirePowerup(string name)
    {
        Powerup powerup = null;
        foreach (Powerup curr in availablePowerups)
        {
            if (curr.compareName(name))
            {
                powerup = curr;
            }
        }
        powerupUI.SetActive(false);

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
        availablePowerups.Clear();
    }

    private void InitializePowerups()
    {
        foreach(Powerup powerup in acquiredPowerups)
        {
            powerup.SetActive();
        }
    }

    public void RemovePowerups()
    {
        foreach(Powerup powerup in acquiredPowerups)
        {
            powerup.SetInactive();
        }
        acquiredPowerups.Clear();
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
    private Powerup GenLightPinsPowerup()
    {
        int randomInt = UnityEngine.Random.Range(1, 100);
        LightPinsPowerup powerup;
        if (randomInt <= 50)
        {
            powerup = new LightPinsPowerup();
            powerup.Initialize(0, 0.9f, "pins");
        } else if (randomInt <= 80)
        {
            powerup = new LightPinsPowerup();
            powerup.Initialize(1, 0.7f, "pins");
        } else
        {
            powerup = new LightPinsPowerup();
            powerup.Initialize(2, 0.5f, "pins");
        }
        return powerup;
    }
    private Powerup GenHeavyBallsPowerup()
    {
        int randomInt = UnityEngine.Random.Range(1, 100);
        HeavyBallPowerup powerup;
        if (randomInt <= 50)
        {
            powerup = new HeavyBallPowerup();
            powerup.Initialize(0, 1.1f, "balls");
        } else if (randomInt <= 80)
        {
            powerup = new HeavyBallPowerup();
            powerup.Initialize(1, 1.3f, "balls");
        } else
        {
            powerup = new HeavyBallPowerup();
            powerup.Initialize(2, 1.5f, "balls");
        }
        return powerup;
    }

}
