using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        // Assuming the gravity vector is the direction you want the left of the object to point to.
        Vector3 gravityDirection = transform.parent.gameObject.GetComponent<GravityControllerMonoDirectional>().gravity;

        Vector3 extrudePosition = gravityDirection + transform.position;
        transform.LookAt(extrudePosition);
    }
}
