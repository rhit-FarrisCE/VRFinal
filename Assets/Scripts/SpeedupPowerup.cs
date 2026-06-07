using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedupPowerup : Powerup
{

    private float speedMultiplier;
    private bool hasTriggered = false;

    public void Initialize(int rarity, float speedMultiplier, string name)
    {
        this.rarity = rarity;
        this.speedMultiplier = speedMultiplier;
        this.name = name;
    }
    
    public override void UpdatePowerup(Powerup otherPowerup)
    {
        SpeedupPowerup other = (SpeedupPowerup) otherPowerup;
        speedMultiplier += other.getMult();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Ball"))
        {
            hasTriggered = true;
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity *= speedMultiplier;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasTriggered = false;
    }

    public float getMult()
    {
        return speedMultiplier;
    }


}
