using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    protected int rarity;
    protected string name;

    public bool compareName(string otherName)
    {
        if (name.Equals(otherName))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public string GetName()
    {
        return name;
    }

    public abstract void UpdatePowerup(Powerup otherPowerup);

    public int getRarity()
    {
        return rarity;
    }
}
