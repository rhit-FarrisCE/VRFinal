using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    private List<Ball> balls = new List<Ball>();

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterBall(Ball ball)
    {
        if (!balls.Contains(ball))
        {
            balls.Add(ball);
        }
    }

    public List<Ball> GetBalls()
    {
        return balls;
    }
}
