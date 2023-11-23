using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamToBody : MonoBehaviour
{
    public Transform targetObject; // The object you want to stay near
    public Vector3 maxDistances = new Vector3(1.0f, 1.0f, 1.0f);

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = targetObject.position;

        float distanceX = Mathf.Abs(currentPosition.x - targetPosition.x);
        float distanceY = Mathf.Abs(currentPosition.y - targetPosition.y);
        float distanceZ = Mathf.Abs(currentPosition.z - targetPosition.z);

        if (distanceX > maxDistances.x)
        {
            currentPosition.x = targetPosition.x + Mathf.Sign(currentPosition.x - targetPosition.x) * maxDistances.x;
        }

        if (distanceY > maxDistances.y)
        {
            currentPosition.y = targetPosition.y + Mathf.Sign(currentPosition.y - targetPosition.y) * maxDistances.y;
        }

        if (distanceZ > maxDistances.z)
        {
            currentPosition.z = targetPosition.z + Mathf.Sign(currentPosition.z - targetPosition.z) * maxDistances.z;
        }

        transform.position = currentPosition;
    }
}