using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBallPowerup : Powerup
{

    private List<Ball> balls = new List<Ball>();
    private float ballWeightMult;

    private float ogBallMass = 5f;

    public void Initialize(int rarity, float ballWeightMult, string name)
    {
        this.rarity = rarity;
        this.ballWeightMult = ballWeightMult;
        this.name = name;
        balls = BallManager.Instance.GetBalls();
    }

    public override void UpdatePowerup(Powerup otherPowerup)
    {
        HeavyBallPowerup other = (HeavyBallPowerup) otherPowerup;
        ballWeightMult += other.getMult();
    }

    public override void SetActive()
    {
        foreach (Ball ball in balls)
        {
            ball.GetComponent<Rigidbody>().mass *= ballWeightMult;
        }
    }

    public override void SetInactive()
    {
        foreach (Ball ball in balls)
        {
            ball.GetComponent<Rigidbody>().mass = ogBallMass;
        }
    }

    public float getMult()
    {
        return ballWeightMult;
    }

    public override string GetDescription()
    {
        if (rarity == 0)
        {
            return "(COMMON) Ball Weight +10%";
        } else if (rarity == 1)
        {
            return "(RARE) Ball Weight +30%";
        } else
        {
            return "(EPIC) Ball Weight +50%";
        }
    }
}
