using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControllerHelium : MonoBehaviour
{
    private GravityManager gm;
    private Vector3 originalPosition;

    [SerializeField]
    private Transform respawnPoint;

    private float maxDistanceFromStart = 200;
    private void Awake()
    {
        gm = GameObject.Find("Gravity Manager").GetComponent<GravityManager>();
        originalPosition = transform.position;
    }
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(-gm.globalGravity * 9.81f * rb.mass);
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