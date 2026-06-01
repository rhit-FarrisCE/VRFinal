using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    [Header("Pin Settings")]
    public float knockDownAngle = 45f;

    private Rigidbody rb;
    public bool isDown;
    private Quaternion initialRotation;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;

        PinManager.Instance.RegisterPin(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            return;
        }
        float currAngle = Quaternion.Angle(transform.rotation, initialRotation);
        if (currAngle > knockDownAngle)
        {
            isDown = true;
        }
    }
}
