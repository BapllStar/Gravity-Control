using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControllerMonoDirectional : MonoBehaviour
{
    public  Vector3 gravity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(gravity * 9.81f * rb.mass); // Replace 9.81 with your desired gravity strength
    }
}
