using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    private float speedMod = 1f;

    private bool hasTriggered = false;

    public void Awake()
    {
        ResetSpeedMod();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Ball"))
        {
            hasTriggered = true;
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity *= speedMod;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasTriggered = false;
    }

    public void SetSpeedMod(float speed)
    {
        speedMod = speed;
    }

    public void ResetSpeedMod()
    {
        speedMod = 1;
    }
}
