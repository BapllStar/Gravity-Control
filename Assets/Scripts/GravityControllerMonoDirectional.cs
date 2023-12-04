using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControllerMonoDirectional : MonoBehaviour
{
    public  Vector3 gravity;
    private Rigidbody rb;
    private Vector3 originalPosition;

    [SerializeField]
    private Transform respawnPoint;

    private float maxDistanceFromStart = 200;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    void FixedUpdate()
    {
        rb.AddForce(gravity * 9.81f * rb.mass);
        if ((transform.position - originalPosition).magnitude >= maxDistanceFromStart) ResetTransform();
    }

    private void ResetTransform()
    {
        rb.velocity = Vector3.zero;
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            return;
        }

        transform.position = originalPosition;
    }
}
