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

    void Awake()
    {
        ballGrabInteractable = GetComponent<XRGrabInteractable>();
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
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
