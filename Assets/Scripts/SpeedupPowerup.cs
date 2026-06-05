using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupPowerup : MonoBehaviour
{

    public float speedMultipler = 2f;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Ball"))
        {
            hasTriggered = true;
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity *= speedMultipler;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasTriggered = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
