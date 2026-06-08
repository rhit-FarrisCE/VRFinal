using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{

    
    private Vector3 startPos;
    private Rigidbody rb;
    private XRGrabInteractable ballGrabInteractable;
    private Vector3 horizontalVelocityToPreserve;
    private bool shouldPreserveHorizontalMomentum = false;

    void Awake()
    {
        ballGrabInteractable = GetComponent<XRGrabInteractable>();
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();

        //Populate BallManager
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Preserve horizontal momentum on bumper collision
        if (collision.gameObject.CompareTag("Bumper"))
        {
            // Store horizontal velocity before physics response
            horizontalVelocityToPreserve = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            shouldPreserveHorizontalMomentum = true;
        }
    }

    private void FixedUpdate()
    {
        // Restore horizontal momentum after collision response is calculated
        if (shouldPreserveHorizontalMomentum)
        {
            rb.velocity = new Vector3(horizontalVelocityToPreserve.x, rb.velocity.y, horizontalVelocityToPreserve.z);
            shouldPreserveHorizontalMomentum = false;
        }
    }
    
    public void Reset()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

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
