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
    public abstract string GetDescription();

    public abstract void SetActive();

    public abstract void SetInactive();

    public int getRarity()
    {
        return rarity;
    }
}
