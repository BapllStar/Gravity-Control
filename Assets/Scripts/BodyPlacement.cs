using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPlacement : MonoBehaviour
{
    [SerializeField]
    private Transform
        head,
        lHand,
        rHand;

    [SerializeField]
    private float
        offset,
        headWeight,
        rHandWeight,
        lHandWeight;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = (NoYAxis(head.localPosition) * headWeight + NoYAxis(lHand.localPosition) * lHandWeight + NoYAxis(rHand.localPosition) * rHandWeight) / (headWeight + rHandWeight + lHandWeight) + new Vector3(0, offset,0);
        transform.localPosition = newPos;
    }

    private Vector3 NoYAxis (Vector3 original)
    {
        return new Vector3(original.x, 0, original.z);
    }
}
