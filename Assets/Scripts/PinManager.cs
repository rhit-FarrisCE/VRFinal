using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{

    public static PinManager Instance;
    private List<BowlingPin> pins = new List<BowlingPin>();

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterPin(BowlingPin pin)
    {
        if (!pins.Contains(pin))
        {
            pins.Add(pin);
        }
    }
    public int GetPinsDown()
    {
        int numPinsDown = 0;
        foreach (BowlingPin pin in pins)
        {
            if (pin.isDown)
            {
                numPinsDown += 1;
            }
        }
        return numPinsDown;
    }
    public int GetTotalPins()
    {
        return pins.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
