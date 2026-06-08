using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class LightPinsPowerup : Powerup
{

    private List<BowlingPin> pins = new List<BowlingPin>();
    private static float og_pin_mass = 5f;

    private float weightDecreaseMult;

    public void Initialize(int rarity, float weightDecreaseMult, string name)
    {
        this.rarity = rarity;
        this.weightDecreaseMult = weightDecreaseMult;
        this.name = name;
        pins = PinManager.Instance.GetPins();
    }

    public override void UpdatePowerup(Powerup otherPowerup)
    {
        LightPinsPowerup other = (LightPinsPowerup) otherPowerup;
        weightDecreaseMult += other.getMult();
    }

    public override void SetActive()
    {
        foreach (BowlingPin pin in pins)
        {
            pin.GetComponent<Rigidbody>().mass *= weightDecreaseMult;
        }
    }
    public override void SetInactive()
    {
        foreach (BowlingPin pin in pins)
        {
            pin.GetComponent<Rigidbody>().mass = og_pin_mass;
        }
    }

    public float getMult()
    {
        return weightDecreaseMult;
    }

    public override string GetDescription()
    {
        if (rarity == 0)
        {
            return "(COMMON) Pin weight -10%";
        } else if (rarity == 1)
        {
            return "(RARE) Pin Weight -30%";
        } else
        {
            return "(EPIC) Pin Weight -50%";
        }
    }

    
}
