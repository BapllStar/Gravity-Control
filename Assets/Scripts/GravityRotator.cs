using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRotator : MonoBehaviour
{
    private GravityManager gm;
    [SerializeField]
    private float speed;
    private void Awake()
    {
        gm = GameObject.Find("Gravity Manager").GetComponent<GravityManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // The step size is equal to speed times frame time.
        float singleStep = speed;

        // Calculate the direction to rotate from the object's down vector towards the target direction
        Vector3 newDirection = Vector3.RotateTowards(-transform.up, gm.globalGravity, singleStep, 0.0f);

        // Draw a ray pointing at our target
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate the rotation to make the object's down direction point at the target
        Quaternion toRotation = Quaternion.FromToRotation(-transform.up, newDirection) * transform.rotation;

        // Smoothly interpolate the rotation towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, singleStep);

    }
}
