using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class LightPinsPowerup : MonoBehaviour
{

    private List<BowlingPin> pins = new List<BowlingPin>();
    private static float og_pin_mass = 5f;

    public void setActive()
    {
        foreach (BowlingPin pin in pins)
        {
            pin.GetComponent<Rigidbody>().mass = 1;
        }
    }
    public void setInactive()
    {
        foreach (BowlingPin pin in pins)
        {
            pin.GetComponent<Rigidbody>().mass = og_pin_mass;
        }
    }

}
